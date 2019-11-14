const requestClubType = 'REQUEST_CLUB';
const receiveClubType = 'RECEIVE_Club';
const initialState = { clubs: [], isLoading: false };

export const actionCreators = {
    requestClubType: startDateIndex => async (dispatch, getState) => {
        if (startDateIndex === getState().weatherForecasts.startDateIndex) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: requestClubType, startDateIndex });

        const url = `api/SampleData/WeatherForecasts?startDateIndex=${startDateIndex}`;
        const response = await fetch(url);
        const forecasts = await response.json();

        dispatch({ type: receiveClubType, startDateIndex, forecasts });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestClubType) {
        return {
            ...state,
            startDateIndex: action.startDateIndex,
            isLoading: true
        };
    }

    if (action.type === receiveClubType) {
        return {
            ...state,
            startDateIndex: action.startDateIndex,
            forecasts: action.forecasts,
            isLoading: false
        };
    }

    return state;
};
