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
                            <div>Hier steht viel Content spaeter und es wird den meisten Platz wegnehmen</div>
                        </div>
                        <footer class="flex-container">
                            <div id="home-btn">Home</div>
                            <div id="leaderboard-btn">Leaderboard</div>
                            <div id="goals-btn">Goals</div>
                            <div id="profile-btn">Profile</div>
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
