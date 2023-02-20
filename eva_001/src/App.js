import React, { Component } from 'react';
import './App.css';


export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    render() {
        return (
            <body>
                <div className="App">
                    <header>EVA</header>
                    <div id="container">
                        <div id="content-container">
                            <p>Hier steht viel Content spaeter und es wird den meisten Platz wegnehmen</p>
                        </div>
                        <footer class="flex-container">
                            <div>Home</div>
                            <div>Leaderboard</div>
                            <div>Goals</div>
                            <div>Profile</div>
                        </footer>
                    </div>
                </div>
            </body>
        );
    }

    async populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}
