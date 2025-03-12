
import AuthorizedView from "../Components/AuthorizedView.tsx";
import NonAuthorizedView from "../Components/NonAuthorizedView.tsx";

function Home() {
    return (
        <NonAuthorizedView />

        <AuthorizedView />
    )
}