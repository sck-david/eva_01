import React, { useState, useEffect } from 'react';
import './Workouts.css';

const WorkoutsComp = () => {
    const [data, setData] = useState(null);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [duration, setDuration] = useState('');
    const [date, setDate] = useState('');

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch('https://localhost:7086/api/Home/getAllWorkouts'); // Replace with your API endpoint
            const json = await response.json();
            setData(json);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const handleSubmit = (event) => {
        event.preventDefault();

        console.log(`Name: ${name}, Description: ${description}, Duration: ${duration}, Date: ${date}`);
        // TODO: Add logic to save the new workout
    };

    return (

            <table>
                <tr>
                    <th>Id</th>
                    <th>UserID</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Duration</th>
                    <th>Date</th>
                </tr>
                {data &&
                    data.map(item => (
                        <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.userId}</td>
                            <td>{item.name}</td>
                            <td>{item.description}</td>
                            <td>{item.duration}</td>
                            <td>{item.date}</td>
                        </tr>
                    ))}
            </table>
    );
};

export default WorkoutsComp;


//const WorkoutsComp = async() => {
//    const tbodyData = await Workouts();
//    console.log(tbodyData);
//    return (
//        <div className='workouts-container'>
//            <h1>Alle Workouts</h1>
//            <table>
//                <thead>
//                    <tr>
//                        <th>Id</th>
//                        <th>UserID</th>
//                        <th>Name</th>
//                        <th>Description</th>
//                        <th>Duration</th>
//                        <th>Date</th>
//                    </tr>
//                </thead>
//                <tbodyData></tbodyData>
//            </table>
//        </div>
//    );
//};

//export default WorkoutsComp;



//const getData = async () => {
//    try {
//        var data;
//        const res = await fetch('https://localhost:7086/api/Home/getAllWorkouts', {
//            method: 'GET',
//            headers: {
//                'Accept': 'application/json',
//            },
//        });  //.then(jso => console.log(jso));s
//       var data = await res.json();
//        //console.log(data);
//        //console.log('****************************************');
//        //console.log(data);
//        return data;
       
//    } catch (error) {
//        console.log('*********ERROR*********');
//    }
//};



//async function Workouts() {
//    const dataJ = await getData();
//    const container = document.createElement("tbody");
//    container.id = "workout-table";
//    container.innerHTML = '';
    
//    for (let item of dataJ) {
//        const tr = document.createElement("tr");
//        const htmlTable = `
//            <td>${item.userId}</td>
//            <td>${item.name}</td>
//            <td>${item.description}</td>
//            <td>${item.duration}</td>
//            <td>${item.date}</td>`

//        tr.innerHTML = htmlTable;
//        container.appendChild(tr);
//    }
    
//   /* console.log(container);*/
//    return (container);
//}





 


