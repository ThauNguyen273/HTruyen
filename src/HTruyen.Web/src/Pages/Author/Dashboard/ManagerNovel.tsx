import { faCloudArrowUp, faFolderPlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import AuthorNovelTable from "../../../Components/Tables/AuthorNovelTable";
import { Link, useParams } from "react-router-dom";

const ManagerNovel: React.FC = () => {
    const {authorId} = useParams()
    return (
        <div className="content px-2 mt-2">
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold items-center text-xl	">
                    <FontAwesomeIcon icon={faCloudArrowUp} className="px-2"/>
                    Danh sách truyện đã tạo
                </h2>
                <Link to={`../manager/novel/create/${authorId}`} className="px-2 rounded border border-solid border-gray-300 dark:border-gray-300">
                    <FontAwesomeIcon icon={faFolderPlus} className="px-2"/>
                    Thêm truyện</Link>
                <div className="mt-2">
                    <AuthorNovelTable/>
                </div>
                
            </div>
        </div>
    )
}
export default ManagerNovel;