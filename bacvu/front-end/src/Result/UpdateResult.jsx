import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

export default function ViewResult() {
    const [mark, setMark] = useState([]);
    const [exmId, setExmdId] = useState('');
    const [stuID, setStuId] = useState('');
    const [exmIdError, setExmIdError] = useState('');
    const [stuIdError, setStuIdError] = useState('');
    const navigate=useNavigate()

    useEffect(()=>{
        if(sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
              Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
        axios
            .get("http://localhost:5099/api/Result/GetAllResult")
            .then((response) => {
                setMark(response.data);
                console.log(response.data);
            })
            .catch((error) => {
                console.error('Error retrieving all results:', error);
                alert('Error retrieving all results. Please try again.');
            });
        }else{
            navigate("/login")
        }
    })
        
   const UpdateRslt = (e) => {
    axios .put("http://localhost:5099/api/Result/UpdateStudent")
    
     
   };

    return (
        <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
            <div className="container">
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>Exam Id</th>
                            <th>Student Id</th>
                            <th>Subject Id</th>
                            <th>Mark</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mark.map((item, index) => (
                            <tr key={index}>
                                <td>{item.examId}</td>
                                <td>{item.studentId}</td>
                                <td>{item.subjectId}</td>
                                <td>{item.marks}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
            <button onClick={GetAllResults} type="button" className="btn btn-outline-primary">
                Get all
            </button>
        </div>
    );
}
