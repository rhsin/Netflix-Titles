import axios from 'axios';

export const FETCH_TITLES_BEGIN = 'FETCH_TITLES_BEGIN';
export const FETCH_TITLES_SUCCESS = 'FETCH_TITLES_SUCCESS';
export const FETCH_DETAILS_SUCCESS = 'FETCH_DETAILS_SUCCESS';
export const FETCH_TITLES_FAILURE = 'FETCH_TITLES_FAILURE';
export const GET_USER = 'GET_USER';
export const SHOW_ERROR = 'SHOW_ERROR';
export const RESET_ERROR = 'RESET_ERROR';

const url = 'https://localhost:44315/api';

export function fetchTitles(url) {
    return dispatch => {
        dispatch({type: FETCH_TITLES_BEGIN});
        axios.get(url)
        .then(res => dispatch({
            type: FETCH_TITLES_SUCCESS,
            titles: res.data
        }))
        .catch(err => dispatch({
            type: FETCH_TITLES_FAILURE,
            error: err.message
        }));
    };
}

export function fetchDetails(title, type) {
    return dispatch => {
        dispatch({type: FETCH_TITLES_BEGIN});
        if (type == 'TV Show') {
            type = 'series'
        };
        axios.get(`${url}/Titles/Details?title=${title}&type=${type}`)
        .then(res => dispatch({
            type: FETCH_DETAILS_SUCCESS,
            details: res.data
        }))
        .catch(err => dispatch(
            showError(err)
        ));
    };
};

export function getUser() {
    return dispatch => {
        axios.get(`${url}/Users/2`)
        .then(res => dispatch({
            type: GET_USER,
            user: res.data
        }))
        .catch(err => dispatch(
            showError(err)
        ));
    };
}

export const fetchAllTitles = () => (
    fetchTitles(`${url}/Titles`)
);

export const fetchSearchTitles = (name, cast, order) => (
    fetchTitles(`${url}/Titles/Filter?name=${name}&cast=${cast}&order=${order}`)
);

export const showMessage = (message) => ({type: SHOW_ERROR, error: message});

export const showError = (err) => ({type: SHOW_ERROR, error: err.message});

export const resetError = () => ({type: RESET_ERROR});