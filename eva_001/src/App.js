import React, { Component } from 'react';
import './App.css';
import Home from './Home';
import Leaderboard from './Leaderboard';
import Profile from './Profile';
import Workouts from './Workouts';
import Goals from './Goals';

export default class App extends Component {
    state = {
        activePage: 'home',
    };

    setActivePage = (page) => {
        this.setState({ activePage: page });
    };

    render() {
        const { activePage } = this.state;

        return (
            <div className="container">
                <div className="header">EVA</div>
                <div className="content-container">
                    {activePage === 'home' && <Home />}
                    {activePage === 'leaderboard' && <Leaderboard />}
                    {activePage === 'profile' && <Profile />}
                    {activePage === 'workout' && <Workouts />}
                    {activePage === 'goals' && <Goals /> }
                </div>
                <div className="footer">
                    <div className="footer-text" onClick={() => this.setActivePage('home')}>
                        <svg id="home-pic" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 567 512" width="30" height="30" ><path d="M575.8 255.5c0 18-15 32.1-32 32.1h-32l.7 160.2c0 2.7-.2 5.4-.5 8.1V472c0 22.1-17.9 40-40 40H456c-1.1 0-2.2 0-3.3-.1c-1.4 .1-2.8 .1-4.2 .1H416 392c-22.1 0-40-17.9-40-40V448 384c0-17.7-14.3-32-32-32H256c-17.7 0-32 14.3-32 32v64 24c0 22.1-17.9 40-40 40H160 128.1c-1.5 0-3-.1-4.5-.2c-1.2 .1-2.4 .2-3.6 .2H104c-22.1 0-40-17.9-40-40V360c0-.9 0-1.9 .1-2.8V287.6H32c-18 0-32-14-32-32.1c0-9 3-17 10-24L266.4 8c7-7 15-8 22-8s15 2 21 7L564.8 231.5c8 7 12 15 11 24z" /></svg>
                    </div>
                    <div className="footer-text" onClick={() => this.setActivePage('leaderboard')}>
                        <svg id="leaderboard-pic" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" width="30" height="30" ><path d="M40 48C26.7 48 16 58.7 16 72v48c0 13.3 10.7 24 24 24H88c13.3 0 24-10.7 24-24V72c0-13.3-10.7-24-24-24H40zM192 64c-17.7 0-32 14.3-32 32s14.3 32 32 32H480c17.7 0 32-14.3 32-32s-14.3-32-32-32H192zm0 160c-17.7 0-32 14.3-32 32s14.3 32 32 32H480c17.7 0 32-14.3 32-32s-14.3-32-32-32H192zm0 160c-17.7 0-32 14.3-32 32s14.3 32 32 32H480c17.7 0 32-14.3 32-32s-14.3-32-32-32H192zM16 232v48c0 13.3 10.7 24 24 24H88c13.3 0 24-10.7 24-24V232c0-13.3-10.7-24-24-24H40c-13.3 0-24 10.7-24 24zM40 368c-13.3 0-24 10.7-24 24v48c0 13.3 10.7 24 24 24H88c13.3 0 24-10.7 24-24V392c0-13.3-10.7-24-24-24H40z" /></svg>
                    </div>
                    <div className="footer-text" onClick={() => this.setActivePage('goals')}>
                        <svg id="goals-pic" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" width="30" height="30"><path d="M448 256A192 192 0 1 0 64 256a192 192 0 1 0 384 0zM0 256a256 256 0 1 1 512 0A256 256 0 1 1 0 256zm256 80a80 80 0 1 0 0-160 80 80 0 1 0 0 160zm0-224a144 144 0 1 1 0 288 144 144 0 1 1 0-288zM224 256a32 32 0 1 1 64 0 32 32 0 1 1 -64 0z" /></svg>
                    </div>
                    <div className="footer-text" onClick={() => this.setActivePage('workout')}>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 650 512" width="30" height="30"><path d="M112 96c0-17.7 14.3-32 32-32h16c17.7 0 32 14.3 32 32V224v64V416c0 17.7-14.3 32-32 32H144c-17.7 0-32-14.3-32-32V384H64c-17.7 0-32-14.3-32-32V288c-17.7 0-32-14.3-32-32s14.3-32 32-32V160c0-17.7 14.3-32 32-32h48V96zm416 0v32h48c17.7 0 32 14.3 32 32v64c17.7 0 32 14.3 32 32s-14.3 32-32 32v64c0 17.7-14.3 32-32 32H528v32c0 17.7-14.3 32-32 32H480c-17.7 0-32-14.3-32-32V288 224 96c0-17.7 14.3-32 32-32h16c17.7 0 32 14.3 32 32zM416 224v64H224V224H416z" /></svg>
                    </div>
                    <div className="footer-text" onClick={() => this.setActivePage('profile')}>
                        <svg id="profile-pic" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" width="30" height="30"><path d="M224 256A128 128 0 1 0 224 0a128 128 0 1 0 0 256zm-45.7 48C79.8 304 0 383.8 0 482.3C0 498.7 13.3 512 29.7 512H418.3c16.4 0 29.7-13.3 29.7-29.7C448 383.8 368.2 304 269.7 304H178.3z" /></svg>
                    </div>
                </div>
            </div>
        );
    }
}