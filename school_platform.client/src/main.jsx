import { createRoot } from 'react-dom/client'
import './index.css'
import Courses from "./Components/Courses.tsx"

const Title = "Language School"

createRoot(document.getElementById('root')).render(
    <div>
        <div className="top-bar">
            <a href='/'>{Title}</a>
        </div>
        <Courses />
    </div>
)
