import logo from './logo.svg';
// import './App.css';
import Home from './Home'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from './LoginPage';
import NoPage from './NoPage';
import AdminDashboard from './Admin/AdminDashBoard'
import StudentDashboard from './Student/StudentDashBoard'
import TeacherDashboard from './Teacher/TeacherDashBoard'
import ExamSch from './Admin/ExamSh';
import Profile from './Admin/Profile';
import TeacherRegister from './Admin/TeacherRegistration';
import TeacherProfile from './Teacher/TeacherProfile';
import ViewResult from './Result/AllResult';
import AddResult from './Result/AddResult';
import StudentProfile from './Student/StudentProfile';
import EditProfile from './Student/EditProfile'
import ResultReportStudent from './Result/ResultReportStudent'
import DislaySAttandanceById from './Attandance/DisplaySAttandanceById'
import ViewStuAttendanceById from './Attandance/ViewStuAttendanceById';
import TEditProfile from './Teacher/TEditProfile';
import ResultById from './Result/ResultById'
import AddStdAttrendance from './Attandance/AddStdAttendance'
import GetallStudentAttendance from './Attandance/GetallStudentAttendance';
import DisplayallStudentAttandance from './Attandance/DisplayallStudentAttandance'
import DisplaySAttandanceByIdForTeacher from './Attandance/DisplaySAttandanceByIdForTeacher';
import AttendanceButton from './AttendanceButton';
import ViewAttendences from './Tattendences/ViewAttendences';
import ViewTeachers from './Admin/ViewTeachers';
import StudRegister from './Admin/StudRegister';
import ViewStudents from './Admin/ViewStudents'
import DisplayTAttendenceReport from './Attandance/DisplayTAttendenceReport';
import TeacherAttendance from './Tattendences/TeacherAttendance';
import UserReg from './User/UserReg'
import GetAllUser from './User/GetAllUser'
import DeleteUser from './User/DeleteUser'
import ClassAssign from './Class/ClassAssign'
import ClassOperation from './Class/ClassOperation'
import GetAllExam from "./Exam/GetAllExam"

function App() {
  return (
    
      // <Home/>
      <div>
          <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home/>}>
            <Route index element={<Home />} />   
          </Route>
          <Route path="login" element={<Login />} />
          <Route path="Admin-Dashboard" element={<AdminDashboard />}>
            <Route path="schedule-exam" element={<ExamSch/>} />
            <Route path="admin-profile" element={<Profile/>} />
            <Route path='teacher-registration' element={<TeacherRegister/>}/>
            <Route path='attendences-sheet' element={<AttendanceButton/>}/>
            <Route path='view-all-attendences' element={<ViewAttendences/>}/>
            <Route path="view-teachers" element={<ViewTeachers/>}/>
            <Route path="add-students" element={<StudRegister/>}/>
            <Route path="view-students" element={<ViewStudents/>}/>
            <Route path="generate-tattendeces-report" element={<DisplayTAttendenceReport/>}/>
            <Route path='add-teacher-attendance' element={<TeacherAttendance/>}/>
            <Route path='stud-registration' element={<StudRegister/>}/>
            <Route path='user-registration' element={<UserReg/>}/>
            <Route path='get-all-user' element={<GetAllUser/>}/>
            <Route path='delete-user' element={<DeleteUser/>}/>
            <Route path='assign-classes' element={<ClassAssign/>}/>
            <Route path='classes-opera' element={<ClassOperation/>}/>
            <Route path='view-exams' element={<GetAllExam/>}/>


          </Route>
          {/* <Route path="Student-Dashboard" element={<StudentDashboard />}>
            <Route path="student-profile" element={<StudentProfile />} />
                <Route path="edit-profile" element={<EditProfile/>}/>
            <Route/>
          </Route> */}
          <Route path="Student-Dashboard" element={<StudentDashboard />}>
            <Route index element={<StudentProfile />} />
            <Route path="student-profile/edit-profile" element={<EditProfile />} />
            <Route path="exam-result" element={<ResultById/>}/>
            <Route path="exam-report" element={<ResultReportStudent/>}/>
            <Route path="attendance-report" element={<DislaySAttandanceById/>}/>
            <Route path="view-attendance" element={<ViewStuAttendanceById/>}/>
          </Route>

          <Route path="teacher-dashboard" element={<TeacherDashboard />}>
            <Route index element={<TeacherProfile/>}/>
            <Route path="teacher-profile/edit-profile" element={<TEditProfile />} />
            <Route path='view-result' element={<ViewResult/>}/>
            <Route path='add-result' element={<AddResult/>}/>
            <Route path='student-attendance' element={<AddStdAttrendance/>}/>
              <Route index element={<AddStdAttrendance/>}/>
              <Route path='student-attendance/view-all-student-attendance' element={<GetallStudentAttendance/>}/>
              <Route path='student-attendance/all-student-attendance-record' element={<DisplayallStudentAttandance/>}/>
              <Route path='student-attendance/student-attendance-record-by-id' element={<DisplaySAttandanceByIdForTeacher/>}/>


            <Route/>



            {/* <Route path="schedule-exam" element={<ScheduleExam />} />
            <Route path="get-marks" element={<GetMarks />} /> */}
          </Route>
          <Route path="*" element={<NoPage/>} />
        </Routes>
      </BrowserRouter>
      </div>
      
   
  );
}

export default App;
