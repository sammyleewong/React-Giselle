import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { ClubData } from './FetchClubs';

interface AddClubDataState {
    title: string;
    loading: boolean;
    clubList: Array<any>;
    clubData: ClubData;
}

export class AddClub extends React.Component<RouteComponentProps<{}>, AddClubDataState> {
    constructor(props: any) {
        super(props);

        this.state = { title: "", loading: true, clubList: [], clubData: new ClubData };

        fetch('api/Club/GetClubList')
            .then(response => response.json() as Promise<Array<any>>)
            .then(data => {
                this.setState({ clubList: data });
            });

       
        var clubid = this.props.match.params["clubid"]; 

        // This will set state for Edit club
        if (clubid > 0) {
            fetch('api/Club/Details/' + clubid)
                .then(response => response.json() as Promise<ClubData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, clubData: data });
                });
        }
        // This will set state for Add club
        else {
            this.state = { title: "Create", loading: false, clubList: [], clubData: new ClubData };
        }
        // This binding is necessary to make "this" work in the callback  
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }


    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm(this.state.clubList);
        return <div>
            <h1>{this.state.title}</h1>
            <h3>Club</h3>
            <hr />
            {contents}
        </div>;
    }
    // This will handle the submit form event.  
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        // PUT request for Edit club
        if (this.state.clubData.clubId) {
            fetch('api/Club/Edit', {
                method: 'PUT',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchclub");
                })
        }
        // POST request for Add club.
        else {
            fetch('api/Club/Create', {
                method: 'POST',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchclub");
                })
        }
    }
    // This will handle Cancel button click event.  
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchclub");
    }
    // Returns the HTML Form to the render() method.  
    private renderCreateForm(countryList: Array<any>) {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="clubId" value={this.state.clubData.clubId} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="clubName" defaultValue={this.state.clubData.clubName} required />
                    </div>
                </div >
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Address">Address</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="clubAddress" defaultValue={this.state.clubData.clubAddress} required />
                    </div>
                </div >

                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Country">Country</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="country" defaultValue={this.state.clubData.country} required />
                    </div>
                </div >
                
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}