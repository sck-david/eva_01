import React from 'react'
import './Workouts.css';

const Workouts = () => {
    return (

        < div className= "workout-container">
            <h2>Workouts</h2>
            <table id="workout-table">
                <thead>
                    <tr >
                        <th>Id</th>
                        <th>UserID</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Duration</th>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    );
};

export default Workouts;

//class Workouts extends React.Component {
//    constructor(props) {
//        super(props);
//        this.state = {
//            workouts : []
//        };
//    }

//    render() {
//        return (
//            <div>
//                <h2>Workouts</h2>
//                <table>
//                    <thead>
//                        <tr>
//                            <th>Id</th>
//                            <th>UserID</th>
//                            <th>Name</th>
//                            <th>Description</th>
//                            <th>Duration</th>
//                            <th>Date</th>
//                        </tr>
//                    </thead>
//                    <tbody>
//                    </tbody>
//                </table>
//            </div>
//        );
//        {
//            this.state.workouts.map(w => (
//                <tr key={w.Id}>
//                    <td>{w.UserID}</td>
//                    <td>{w.Name}</td>
//                    <td>{w.Dscription}</td>
//                    <td>{w.Duration}</td>
//                    <td>{w.Data}</td>
//                </tr>
//            ))
//        }
    
//    }

 


