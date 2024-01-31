import { Link, useParams } from "react-router-dom";
import AuthorChapterTable from "../../../Components/Tables/AuthorChapterTable";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBookOpen, faTicket } from "@fortawesome/free-solid-svg-icons";


const ListChapterNovel: React.FC = () => {
    const {novelId} = useParams()
    return (
        <div className="content px-2 mt-2">
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold items-center text-xl	">
                    <FontAwesomeIcon icon={faBookOpen} className="px-2"/>
                    Danh sách chương của  đã tạo
                </h2>
                <Link to={`../manager/novel/${novelId}/create-chapter`} className="px-2 rounded border border-solid border-gray-300 dark:border-gray-300">
                    <FontAwesomeIcon icon={faTicket} className="px-2"/>
                    Thêm chương</Link>
                <div className="mt-2">
                    <AuthorChapterTable/>
                </div>
            </div>
        </div>
    )
}
export default ListChapterNovel;