import axios from 'axios';
import React, { useEffect, useState } from 'react';
 
export default function EditTeacherAttendance() {
    const [teachers, setTeachers] = useState([]);
    const [statusChange, setStatusChange] = useState("");
 
    useEffect(() => {
        axios
            .get("http://localhost:5099/api/T_Attendance/GetAllTeacherAttendance")
            .then((response) => {
                // console.log(response.data);
                setTeachers(response.data);
            });
    }, []);
 
    function UpdateAttendance(attendanceId, date, teacherId) {
        let attendance = {
            attendanceId: attendanceId,
            teacherId: teacherId,
            date: date,
            status: Boolean(statusChange),
        };
        setStatusChange("")
        console.log(attendance);
        axios
            .put("http://localhost:5099/api/T_Attendance/UpdateTeacherAttendance", attendance)
            .then((response) => {
                console.log(response.data);
                alert("Attendance Updated Successfully")
                window.location.reload()
            });
            
    }
 
    return (
        <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Teacher Id</th>
                        <th>Date</th>
                        <th>Current Status</th>
                        <th>Change</th>
                    </tr>
                </thead>
                <tbody>
                    {teachers.map((item) => {
                        return (
                            <tr key={item.attendanceId}>
                                <td>{item.teacherId}</td>
                                <td>{item.date}</td>
                                <td>{item.status ? "Present" : "Absent"}</td>
                                <td>
                                    <select onChange={(e) => setStatusChange(e.target.value)}>
                                        <option value="false">Absent</option>
                                        <option value="true">Present</option>
                                    </select>
                                </td>
                                <td>
                                    <button onClick={() => UpdateAttendance(item.attendanceId, item.date, item.teacherId)}>Update</button>
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        </div>
    );
}