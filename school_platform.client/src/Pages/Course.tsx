import * as React from "react"
import { useEffect, useState } from "react";
//interface Course {
//    Name: string;
//    Description: string;
//}

function Course() {
    const [courses, setCourses] = useState([]);

    const CoursesList = courses.map((course, index) => (
        <li key={index}>
            {course.Name}: {course.Description}
        </li>));

    useEffect(() => {
        fetch('/courses')
            .then(response => response.json())
            .then(data => setCourses(data));
    }, []);

    return (
        <div>
            <h1>Courses</h1>
            <ul>
                {CoursesList}
            </ul>
        </div>
    );
}

export default Course;