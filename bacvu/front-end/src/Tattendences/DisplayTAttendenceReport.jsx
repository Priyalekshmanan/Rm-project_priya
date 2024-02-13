import axios from 'axios'
import React, { useState } from 'react'
 
export default function DisplayTAttendenceReport() {
    const[tstartdate,setTstartdate]=useState("")
    const[tenddate,setTenddate]=useState("")
    const[disp,setDisp]=useState([])
    const [startdateError, setStartDateError] = useState('');
    const [enddateError, setEndDateError] = useState('');
 
    const GenerateReport=(e)=>{
         e.preventDefault(); // Prevent default form submission behavior
 
        //Reset errors
        setStartDateError('');
        setEndDateError('');
 
        // Validation
        let isValid = true;
        if (!startdateError) {
             setStartDateError('Startdate is required');
            isValid = false;
        }
        if (!enddateError) {
           setEndDateError('EndDate is required');
            isValid = false;
        }
   
        if(isValid){
        axios
        // get("http://localhost:5099/api/DisplayAttendance/AllTeacherAttendence/"+tstartdate+"&"+tenddate)
        .get(`http://localhost:5099/api/DisplayAttendance/AllTeacherAttendence?startdt=${tstartdate}&enddt=${tenddate}`)
        .then((response)=>{
            console.log(response.data);
            setDisp(response.data);
        })
        .catch((error)=>{
            console.log("Error in generation report",error);
            alert("error in generating report");
        });
    }
       
}
  return (
    <div className='main-content position-relative max-height-vh-100 h-100 border-radius-lg'>
     <form className="d-flex justify-content-end">
                    <div className="mb-3">
                        <input
                            onChange={(e) => setTstartdate(e.target.value)}
                            type="date"
                             className={`form-control ${startdateError && 'is-invalid'}`}
                        />
                         {startdateError && <div className="invalid-feedback">{startdateError}</div>} 
                    </div>
                    <div className="mb-3">
                        <input
                            onChange={(e) => setTenddate(e.target.value)}
                            type="date"
                            className={`form-control ${enddateError && 'is-invalid'}`}
                        />
                       {enddateError && <div className="invalid-feedback">{enddateError}</div>} 
                    </div>
                    <button onClick={GenerateReport} className="btn btn-primary" type="submit">
                      Generate Report
                    </button>
                </form>
                <table  className='table table-striped'>
            <thead>
                <tr>
                 
                    <th>teacherId</th>
                    <th>presentDays</th>
                    <th>absentDays</th>
                    <th>totalWorking</th>  
                </tr>
            </thead>
            <tbody>
               
                 {
                    disp.map((item,index)=>{
                        return(
                            <tr key={index}>
                                <td>{item.teacherId}</td>
                                <td>{item.presentDays}</td>
                                <td>{item.absentDays}</td>
                                <td>{item.totalWorking}</td>
                               
 
                            </tr>
                        )
                    })
                 }
            </tbody>
        </table>
 
    </div>
  )
}