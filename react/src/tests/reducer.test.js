import { initialState, reducer } from '../redux/store';
import {
    FETCH_TITLES_BEGIN,
    FETCH_TITLES_SUCCESS,
    FETCH_DETAILS_SUCCESS,
    FETCH_TITLES_FAILURE,
    GET_USER,
    SHOW_ERROR,
    RESET_ERROR
} from '../redux/actions';

const titles = [
    {id: 1, name: 'Title 1'},
    {id: 2, name: 'Title 2'}
];

const details = {rating: 9.5, runtime: "90 mins"};

const user = {name: 'Ryan', email: 'ryan@test.com'};

const error = 'Resource Not Found';

describe('reducer', () => {
    test('return initial state', () => {
        expect(reducer(undefined, {})).toEqual(initialState);
    });

    test('handle FETCH_TITLES_BEGIN', () => {
        expect(reducer({}, {type: FETCH_TITLES_BEGIN}))
            .toEqual({loading: true, error: null});
    });

    test('handle FETCH_TITLES_SUCCESS', () => {
        expect(reducer({}, {type: FETCH_TITLES_SUCCESS, titles: titles}))
            .toEqual({titles: titles, loading: false});
    });

    test('handle FETCH_DETAILS_SUCCESS', () => {
        expect(reducer({}, {type: FETCH_DETAILS_SUCCESS, details: details}))
            .toEqual({details: details, loading: false});
    });
    
    test('handle FETCH_TITLES_FAILURE', () => {
        expect(reducer({}, {type: FETCH_TITLES_FAILURE, error: error}))
            .toEqual({error: error, loading: false});
    });

    test('handle GET_USER', () => {
        expect(reducer({}, {type: GET_USER, user: user}))
            .toEqual({user: user});
    });

    test('handle SHOW_ERROR', () => {
        expect(reducer({}, {type: SHOW_ERROR, error: error}))
            .toEqual({error: error});
    });

    test('handle RESET_ERROR', () => {
        expect(reducer({}, {type: RESET_ERROR}))
            .toEqual({details: null, error: null});
    });
});