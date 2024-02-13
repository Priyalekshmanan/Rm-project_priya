import React from 'react'
import { Link } from 'react-router-dom'

export default function AttendanceButton() {
  return (
    <div className='d-flex justify-content-around my-5'>
      <Link className="btn btn-primary" href="#" role="button" to="./">
      Add Student
      </Link>
      <Link className="btn btn-primary" href="#" role="button" to="view-all-student-attendance">
    View All
      </Link>
      
      <Link className="btn btn-primary" href="#" role="button" to="student-attendance/all-student-attendance-record">
      All Record
      </Link>
      <a name id className="btn btn-primary" href="#" role="button">Record By Id</a>
    </div>
  )
}
