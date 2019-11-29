import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/WeatherForecasts';

class FetchClubs extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    render() {
        return (
            <div>
                <h1>Clubs</h1>
                <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
                {renderClubsTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
    }
}

function renderClubsTable(props) {
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>Club</th>
                    <th>Country</th>               
                </tr>
            </thead>
            <tbody>
                {props.club.map(club =>
                    <tr key={club.dateFormatted}>
                        <td>{club.club}</td>
                        <td>{club.country}</td>
                   
                    </tr>
                )}
            </tbody>
        </table>
    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.startDateIndex || 0) - 5;
    const nextStartDateIndex = (props.startDateIndex || 0) + 5;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/fetch-data/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/fetch-data/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.clubType,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchClubs);
