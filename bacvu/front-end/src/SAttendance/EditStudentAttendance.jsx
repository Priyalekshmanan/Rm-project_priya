
import axios from 'axios';
import React, { useEffect, useState } from 'react';

export default function EditStudentAttendance() {
    const [classes, setClasses] = useState([]);
    const [clsId, setClsId] = useState("");
    const [attendance, setAttendance] = useState([]);
    const [statusChange, setStatusChange] = useState(false);

    useEffect(() => {
        axios
            .get("http://localhost:5099/api/ClassM/GetAllClass")
            .then((response) => {
                setClasses(response.data);
            });
    }, []);

    useEffect(() => {
        console.log(clsId);
        if (clsId) {
            axios
                .get("http://localhost:5099/api/S_Attendance/GetAttendanceByClassID/" + clsId)
                .then((response) => {
                    console.log(response.data);
                    setAttendance(response.data);
                });
        }
    }, [clsId]);

    function UpdateAttendance(attendanceId, date, studentId) {
        const sAttendance = {
            attendanceId: attendanceId,
            classId: clsId,
            studentId: studentId,
            date: date,
            status: statusChange,
        };

        axios
            .put("http://localhost:5099/api/S_Attendance/UpdateStudentAttendance", sAttendance)
            .then((response) => {
                console.log(response.data);
                alert("Attendance Updated Successfully")
                window.location.reload()
                setStatusChange(false); // Reset status change after updating
            });
    }

    return (
        <div className='main-content position-relative max-height-vh-100 h-100 border-radius-lg'>
            <select onChange={(e) => setClsId(e.target.value)}>
                <option value="">Select Class</option>
                {classes.map((item) => (
                    <option key={item.classId} value={item.classId}>
                        {item.classId}
                    </option>
                ))}
            </select>
            <table>
                <thead>
                    <tr>
                        <th>Student Id</th>
                        <th>Date</th>
                        <th>Current Status</th>
                        <th>Change</th>
                    </tr>
                </thead>
                <tbody>
                    {attendance.map((item) => (
                        <tr key={item.attendanceId}>
                            <td>{item.studentId}</td>
                            <td>{item.date}</td>
                            <td>{item.status ? "Present" : "Absent"}</td>
                            <td>
                                <select onChange={(e) => setStatusChange(e.target.value === "true")}>
                                    <option value="false">Absent</option>
                                    <option value="true">Present</option>
                                </select>
                            </td>
                            <td>
                                <button onClick={() => UpdateAttendance(item.attendanceId, item.date, item.studentId)}>
                                    Update
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}