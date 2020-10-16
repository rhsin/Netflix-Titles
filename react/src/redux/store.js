import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import {
    FETCH_TITLES_BEGIN,
    FETCH_TITLES_SUCCESS,
    FETCH_TITLES_FAILURE,
    GET_USER,
    SHOW_ERROR,
    RESET_ERROR
} from './actions';

export const initialState = {
    titles: [],
    user: {name: 'Guest', email: 'guest@test.com'},
    loading: false,
    error: null
};

export function reducer(state = initialState, action) {
    console.log('reducer', state, action);

    switch(action.type) {
        case FETCH_TITLES_BEGIN:
            return {
                ...state,
                loading: true,
                error: null
            };
        case FETCH_TITLES_SUCCESS:
            return {
                ...state,
                titles: action.titles,
                loading: false
            };
        case FETCH_TITLES_FAILURE:
            return {
                ...state,
                error: action.error,
                loading: false
            };
        case GET_USER:
            return {
                ...state,
                user: action.user
            };
        case SHOW_ERROR:
            return {
                ...state,
                error: action.error
            };
        case RESET_ERROR:
            return {
                ...state,
                error: null
            };
        default:
            return state;
    }
}

const store = createStore(
    reducer,
    applyMiddleware(thunk)
);

export default store;