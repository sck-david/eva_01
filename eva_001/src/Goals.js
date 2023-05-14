import React, { useState, useEffect } from 'react'
import './Goals.css';


/*const Goals = () => {

    return (

        <div className="goals-container">
            <h1>Goals</h1>
        </div>
    );
};*/

const Goals = () => {
    const [data, setData] = useState(null);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch('https://localhost:7086/api/Home/getGoals/2'); // Replace with your API endpoint
            const json = await response.json();
            setData(json);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    return (
        // Render your component with the received data
        // For example, you can map through an array of data and render each item
        // or display specific data fields in your UI
        <div id="workout-container" class="container mt-3 text-white">
            <table>

                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>End-Date</th>

                </tr>

                {data &&
                    data.map(item => (
                        <tr
                            key={item.id}>
                            <td>{item.name}</td>
                            <td>{item.description}</td>
                            <td>{item.endDate}</td>

                        </tr>
                    ))}
            </table>
        </div>
    );
};

export default Goals;