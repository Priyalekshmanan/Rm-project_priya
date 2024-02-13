import axios from 'axios';
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

export default function ViewAttendences() {
    const [attendences, setAttendences] = useState([]);//getting all result
    const [teacherId, setTeacherId] = useState('');
    const [tattendenceIdError, setTAttendencesIdError] = useState('');
    const navigate=useNavigate()
    

    const GetAttendencesByTeachID = (e) => {
        if (sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
              Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
        e.preventDefault(); // Prevent default form submission behavior

        // Reset errors
        setTAttendencesIdError('');
    
        // Validation
        let isValid = true;
        if (!teacherId) {
            setTAttendencesIdError('Teacher ID is required');
            isValid = false;
        }
        

        if (isValid) {
            axios
                .get("http://localhost:5099/api/T_Attendance/GetTeacherAttandance/"+teacherId,{headers})
                .then((response) => {
                    setAttendences(response.data)
                    console.log(response.data);
                })
                .catch((error) => {
                    console.error('Error retrieving attendences:', error);
                    alert('Error retrieving attendences. Please try again.');
                });
        }
    }
    else{
        navigate("/login")
    }
    };

    const GetAllAttendences = () => {
        if (sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
              Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
        axios
            .get("http://localhost:5099/api/T_Attendance/GetAllTeacherAttendance",{headers})
            .then((response) => {
                if(response.data.status==false){
                    response.data.status="Absent"
                }
                else{
                    response.data.status="Present";
                }
                console.log(response.data);
                setAttendences(response.data);
                
            })
            .catch((error) => {
                console.error('Error retrieving all attendences:', error);
                alert('Error retrieving all attendences. Please try again.');
            });
        }
        else{
            navigate("/login")
        }
    };

    return (
        <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
            <div className="container">
                <form className="d-flex justify-content-end">
                    <div className="mb-3">
                        <input
                            onChange={(e) => setTeacherId(e.target.value)}
                            type="text"
                            className={`form-control ${tattendenceIdError && 'is-invalid'}`}
                            placeholder="Enter Teacher ID"
                        />
                        {tattendenceIdError && <div className="invalid-feedback">{tattendenceIdError}</div>}
                    </div>
                    <button onClick={GetAttendencesByTeachID} className="btn btn-success ms-2" type="submit">
                        View
                    </button>
                    {/* <Link to="/Admin-DashBoard/attendences-sheet" className="btn btn-success ms-2">
                    <button type="button">Back</button></Link> */}
                </form>

                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>AttendencesId</th>
                            <th>TeacherId</th>
                            <th>Date</th>
                            <th>Status</th>
                            
                        </tr>
                    </thead>
                    <tbody>
                        {attendences.map((item) => (
                            <tr key={item.teacherId}>
                                <td>{item.attendanceId}</td>
                                <td>{item.teacherId}</td>
                                <td>{item.date}</td>
                                <td>{item.status?"Present" :"Absent"}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
            <button onClick={GetAllAttendences} type="button" className="btn btn-outline-primary">
                Get all
            </button>
        </div>
    );
}
