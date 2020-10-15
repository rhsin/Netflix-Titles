import React from 'react';
import { render } from '@testing-library/react';
import App from '../App';

test('renders search titles input', () => {
    const { getByText } = render(<App />);
    const inputElement = getByText(/Search Titles/);
    expect(inputElement).toBeInTheDocument();
});

test('renders titles results count', () => {
    const { getByText } = render(<App />);
    const textElement = getByText(/Results:/);
    expect(textElement).toBeInTheDocument();
});

