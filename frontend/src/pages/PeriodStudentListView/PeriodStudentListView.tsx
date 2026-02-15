import StudentListViewRenderer from "./components/StudentListViewRenderer";

export default function PeriodStudentListView() {

    return (
        <div style={{margin: "1em", display: "flex", flexDirection: "column", alignItems: "center"}}>
            <h1>Period 1 - Student List View</h1>
            <StudentListViewRenderer/>
        </div>
    )
}