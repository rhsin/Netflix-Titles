import axios from 'axios';

export const FETCH_TITLES_BEGIN = 'FETCH_TITLES_BEGIN';
export const FETCH_TITLES_SUCCESS = 'FETCH_TITLES_SUCCESS';
export const FETCH_TITLES_FAILURE = 'FETCH_TITLES_FAILURE';
export const GET_USER = 'GET_USER';
export const SHOW_ERROR = 'SHOW_ERROR';
export const RESET_ERROR = 'RESET_ERROR';

const url = 'http://localhost:8000/api/';

export function fetchTitles(slug) {
    return dispatch => {
        dispatch({type: FETCH_TITLES_BEGIN});
        axios.get(url + slug)
        .then(res => dispatch({
            type: FETCH_TITLES_SUCCESS,
            titles: res.data.data
        }))
        .catch(err => dispatch({
            type: FETCH_TITLES_FAILURE,
            error: err.message
        }));
    };
}

export function getUser() {
    return dispatch => {
        axios.get(url + 'admin')
        .then(res => dispatch({
            type: GET_USER,
            user: res.data
        }))
        .catch(err => console.log(err));
    };
}

export const fetchAllTitles = () => fetchTitles('titles');

export const showError = (err) => ({type: SHOW_ERROR, error: err.message});

export const resetError = () => ({type: RESET_ERROR});