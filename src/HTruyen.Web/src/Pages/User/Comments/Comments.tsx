import { faBook, faCircleInfo, faComments, faStar } from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { useEffect, useState } from "react"
import { Link, useParams } from "react-router-dom"
import { GetNovel, Novel } from "../../../Services/Novels/NovelService"

const Comment: React.FC = () => {
    const {novelId} = useParams<{novelId: string}>()
    const [novel, setNovel] = useState<Novel | null>(null)
    
    useEffect(() => {
        const fetchNovel = async () => {
            try {
                const fetchNovel = await GetNovel(novelId)
                setNovel(fetchNovel)
            } catch (error) {
                console.log("Error fetching novel")
            }
        }

        fetchNovel()
    },[novelId])

    return (
        <div className="chapter-content p-2">
            <div className="w-full p-4 mb-2 rounded overflow-hidden border-gray-300 dark:bg-gray dark:bg-gray-300">
                <div className="flex items-center justify-between">
                    <Link to={`/novel/${novel?.metalTitle}/${novel?.id}`} className="flex flex-col items-center">
                        <FontAwesomeIcon icon={faBook} className="mb-1"/>
                        Truyện
                    </Link>
                    <Link to={``} className="flex flex-col items-center">
                        <FontAwesomeIcon icon={faStar} className="mb-1"/>   
                        Đề Cử
                    </Link>
                    <Link to={`/novel/${novel?.metalTitle}/${novel?.id}/binh-luan`} className="flex flex-col items-center">
                        <FontAwesomeIcon icon={faComments} className="mb-1"/>
                        Bình Luận
                    </Link>
                    <Link to={`/novel/${novel?.metalTitle}/${novel?.id}/info`} className="flex flex-col items-center">
                        <FontAwesomeIcon icon={faCircleInfo} className="mb-1"/>
                        Thông Tin
                    </Link>
                </div>
            </div>
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 ">
                    <p className="text-center font-bold">Danh sách bình luận truyện {novel?.name}</p>
                </h2>
            </div>
        </div>
    )
}

export default Comment