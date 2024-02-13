import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

export default function GetSemwiseResultStud() {
  // const [studId, setStudId] = useState('');
  const [sem, setSem] = useState('');
  const [res, setRes] = useState([]);
  const [error, setError] = useState(null);
  let Stid = sessionStorage.getItem("uid");
  const navigate=useNavigate()

  function GetResult() {
    if(sessionStorage.getItem("token") != null) {
      console.log(sessionStorage.getItem("token"));
      const headers = {
        Authorization: `Bearer ${sessionStorage.getItem("token")}`,
      };
    
    axios
      .get("http://localhost:5099/api/Result/GetSemAllres/"+Stid+"/"+sem)
      .then((response) => {
        console.log(response.data);
        setRes(response.data);
        setError(null); // Clear previous errors on successful response
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        setError('Error fetching data. Please try again.'); // Set an error message
      });
    }else{
      navigate("/logn")
    }
  }

  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg" >
      <table>
        <tbody>
          <tr>
            <td>Sem:</td>
            <td>
            <select onChange={(e) => setSem(e.target.value)}>
                <option value="select">Select Sem</option>
                <option value="S1">S1</option>
                <option value="S2">S2</option>
                <option value="S3">S3</option>
                <option value="S4">S4</option>
                <option value="S5">S5</option>
                <option value="S6">S6</option>
                <option value="S7">S7</option>
                <option value="S8">S8</option>
              </select>
            </td>
          </tr>
          <tr>
            <td>
              <button onClick={GetResult}>Get</button>
            </td>
          </tr>
        </tbody>
      </table>

      {error && <p style={{ color: 'red' }}>{error}</p>}

      <table className="table table-striped">
        <tbody>
          {res.map((item) => (
            <React.Fragment key={item.examId}>
              <tr>
                <td>Exam Id:</td>
                <td>{item.examId}</td>
              </tr>
              <tr>
                <td>Student Id:</td>
                <td>{item.stu_id}</td>
              </tr>
              {item.subjectResults.map((result) => (
                <tr key={result.sub_Id}>
                  <td>{result.sub_Id}:</td>
                  <td>{result.marks}</td>
                </tr>
              ))}
              <tr>
                <td>Total Marks:</td>
                <td>{item.totalMarks}</td>
              </tr>
            </React.Fragment>
          ))}
        </tbody>
      </table>
    </div>
  );
}
