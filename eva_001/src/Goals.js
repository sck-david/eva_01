import React, { useState, useEffect } from 'react';
import './Goals.css';

const Goals = () => {
    const [data, setData] = useState(null);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [endDate, setEndDate] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        console.log(`Name: ${name}, Description: ${description}, End Date: ${endDate}`);
        // TODO: Add logic to save the new goal
    };

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
        <div className="goals-container">
            <h1>Goals</h1>
            <div className="goal-form">
                <h3>Create a Goal</h3>
                <form onSubmit={handleSubmit}>
                    <label>
                        Name:
                        <input type="text" value={name} onChange={e => setName(e.target.value)} />
                    </label>
                    <label>
                        Description:
                        <textarea value={description} onChange={e => setDescription(e.target.value)} />
                    </label>
                    <label>
                        End Date:
                        <input type="date" value={endDate} onChange={e => setEndDate(e.target.value)} />
                    </label>
                    <input type="submit" value="Create Goal" />
                </form>
            </div>
            <table>
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>End-Date</th>
                </tr>
                {data &&
                    data.map(item => (
                        <tr key={item.id}>
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
