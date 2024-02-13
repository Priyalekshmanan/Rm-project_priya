import axios from 'axios';
import React, { useState } from 'react';
import './AddResult.css'; // Import the CSS file
import { useNavigate } from 'react-router-dom';

export default function AddResult() {
    const [resultId, setResultId] = useState("");
    const [examId, setExamId] = useState("");
    const [semester, setSemester] = useState("");
    const [studentId, setStudentId] = useState("");
    const [subjectId, setSubjectId] = useState("");
    const [mark, setMark] = useState(0);
    const [errors, setErrors] = useState({});
    const navigate=useNavigate()

    const validateForm = () => {
        let errors = {};

        if (!resultId.trim()) {
            errors.resultId = "Result Id is required";
        }
        if (!examId.trim()) {
            errors.examId = "Exam Id is required";
        }
        if (!studentId.trim()) {
            errors.studentId = "Student Id is required";
        }
        if (!subjectId.trim()) {
            errors.subjectId = "Subject Id is required";
        }
        if (!mark) {
            errors.mark = "Mark is required";
        }

        setErrors(errors);
        return Object.keys(errors).length === 0;
    };

    const handleSubmit = (e) => {
        if(sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
              Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
      
        e.preventDefault();
        if (validateForm()) {
            const marks = {
                resultId: resultId,
                examId: examId,
                studentId: studentId,
                subjectId: subjectId,
                mark: mark,
                semName:semester,
            };
            console.log(marks);
            axios
                .post("http://localhost:5099/api/Result/Add_Result", marks,{headers})
                .then((response) => {
                    console.log(response.data);
                })
                .catch((error) => console.log(error));
        }
    }else{
        navigate("/login")
    }
    };

    return (
        <div className="my-5 main-content position-relative max-height-vh-100 h-100 border-radius-lg">
            <form onSubmit={handleSubmit}>
                <div className="mb-3 row">
                    <label htmlFor="resultId" className="col-sm-2 col-form-label">Result Id:</label>
                    <div className="col-sm-10">
                        <input type="text" className="form-control" id="resultId" value={resultId} onChange={(e) => setResultId(e.target.value)} />
                        {errors.resultId && <div className="text-danger">{errors.resultId}</div>}
                    </div>
                </div>
                <div className="mb-3 row">
                    <label htmlFor="examId" className="col-sm-2 col-form-label">Exam Id:</label>
                    <div className="col-sm-10">
                        <input type="text" className="form-control" id="examId" value={examId} onChange={(e) => setExamId(e.target.value)} />
                        {errors.examId && <div className="text-danger">{errors.examId}</div>}
                    </div>
                </div>
                <div className="mb-3 row">
                <td>
                  <select className="form-control form-control-lg" value={semester} onChange={e => setSemester( e.target.value )} >
                    <option value="">Semester</option>
                    <option value="Sem 1">Sem1</option>
                    <option value="Sem 2">Sem2 </option>
                    <option value="Sem 3">Sem3</option>
                    <option value="Sem 4">Sem4</option>
                    <option value="Sem 5">Sem5</option>
                    <option value="Sem 6">Sem6 </option>
                    <option value="Sem 7">Sem7</option>
                    <option value="Sem 8">Sem8</option>
                  </select>
                  {errors.semester && <span className="error">{errors.semester}</span>}
                  </td>
                    <div className="col-sm-10">
                        {/* <input type="text" className="form-control" id="examId" value={semester} onChange={(e) => setSemester(e.target.value)} /> */}
                        {errors.examId && <div className="text-danger">{errors.examId}</div>}
                    </div>
                </div>
                <div className="mb-3 row">
                    <label htmlFor="studentId" className="col-sm-2 col-form-label">Student Id:</label>
                    <div className="col-sm-10">
                        <input type="text" className="form-control" id="studentId" value={studentId} onChange={(e) => setStudentId(e.target.value)} />
                        {errors.studentId && <div className="text-danger">{errors.studentId}</div>}
                    </div>
                </div>
                <div className="mb-3 row">
                    <label htmlFor="subjectId" className="col-sm-2 col-form-label">Subject Id:</label>
                    <div className="col-sm-10">
                        <input type="text" className="form-control" id="subjectId" value={subjectId} onChange={(e) => setSubjectId(e.target.value)} />
                        {errors.subjectId && <div className="text-danger">{errors.subjectId}</div>}
                    </div>
                </div>
                <div className="mb-3 row">
                    <label htmlFor="mark" className="col-sm-2 col-form-label">Mark:</label>
                    <div className="col-sm-10">
                        <input type="text" className="form-control" id="mark" value={mark} onChange={(e) => setMark(e.target.value)} />
                        {errors.mark && <div className="text-danger">{errors.mark}</div>}
                    </div>
                </div>
                <div className="mb-3 row">
                    <div className="col-sm-10 offset-sm-2">
                        <button type="submit" className="btn btn-primary">Add</button>
                    </div>
                </div>
            </form>
        </div>
    );
}
