import React from 'react';
import { render } from '@testing-library/react';
import App from '../App';

test('renders current or default user email', () => {
    const { getByText } = render(<App />);
    const textElement = getByText(/@/);
    expect(textElement).toBeInTheDocument();
});

test('renders current or default user titles', () => {
    const { getByText } = render(<App />);
    const textElement = getByText(/Titles:/);
    expect(textElement).toBeInTheDocument();
});

test('renders search titles input', () => {
    const { getByText } = render(<App />);
    const inputElement = getByText(/Search Titles/);
    expect(inputElement).toBeInTheDocument();
});

test('renders search filter button', () => {
    const { getByText } = render(<App />);
    const buttonElement = getByText(/Filter/);
    expect(buttonElement).toBeInTheDocument();
});

test('renders titles results count', () => {
    const { getByText } = render(<App />);
    const textElement = getByText(/Results:/);
    expect(textElement).toBeInTheDocument();
});

