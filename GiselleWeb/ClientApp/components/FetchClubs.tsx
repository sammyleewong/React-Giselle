import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchClubsDataState {
    clubList: ClubData[];
    loading: boolean;
}


export class FetchClubs extends React.Component<RouteComponentProps<{}>, FetchClubsDataState> {
    constructor() {
        super();
        this.state = { clubList: [], loading: true };

        fetch('api/Club/Index')
            .then(response => response.json() as Promise<ClubData[]>)
            .then(data => {
                this.setState({ clubList: data, loading: false });
            });

        // This binding is necessary to make "this" work in the callback  
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);
    }
    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderClubTable(this.state.clubList);
        return <div>
            <h1>Club Data</h1>
            <p>This component demonstrates fetching Vlubta from the server.</p>
            <p>
                <Link to="/addclub">Create New</Link>
            </p>
            {contents}
        </div>;
    }
    // Handle Delete request for an club  
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete club with Id: " + id))
            return;
        else {
            fetch('api/Club/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        clubList: this.state.clubList.filter((rec) => {
                            return (rec.clubId != id);
                        })
                    });
            });
        }
    }
    private handleEdit(id: number) {
        this.props.history.push("/club/edit/" + id);
    }
    // Returns the HTML table to the render() method.  
    private renderClubTable(clubList: ClubData[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>ClubId</th>
                    <th>Name</th>
                    <th>Address</th>
                    <th>Country</th>
                </tr>
            </thead>
            <tbody>
                {clubList.map(club =>
                    <tr key={club.clubId}>
                        <td></td>
                        <td>{club.clubId}</td>
                        <td>{club.clubName}</td>
                        <td>{club.clubAddress}</td>
                        <td>{club.country}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(club.clubId)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(club.clubId)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}
export class ClubData {
    clubId: number = 0;
    clubName: string = "";
    clubAddress: string = "";
    country: string = "";
}