import { faBook, faCircleInfo, faComments, faPlus, faStar } from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { useEffect, useState } from "react"
import { Link, useParams } from "react-router-dom"
import { GetNovel, Novel } from "../../../Services/Novels/NovelService"
import { GetNomiByNovel, Nominations } from "../../../Services/Nominations/NominationService"
import LazyLoadImage from "../../../Components/Loading/LazyLoadImage"

const Nomination: React.FC = () => {
    const {novelId} = useParams<{novelId: string}>()
    const [novel, setNovel] = useState<Novel | null>(null)
    const [nomination, setNomination] = useState<Nominations[]>([])
    
    useEffect(() => {
        const fetchNovel = async () => {
            try {
                const fetchNovel = await GetNovel(novelId)
                setNovel(fetchNovel)
            } catch (error) {
                console.log("Error fetching novel")
            }
        }

        const fetchNominations =  async () => {
            try {
                const fetchNomination = await GetNomiByNovel(novelId)
                setNomination(fetchNomination)
            } catch (error) {
                console.log("Error fetching nominations:", error)
            }
        }

        fetchNovel()
        fetchNominations()
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
                    <p className="text-center font-bold">Gửi ý kiến đánh giá của bạn cho truyện {novel?.name} của tác giả {novel?.author.authorName}</p>
                </h2>
                <div>
                    <button className="flex-1 mr-2 px-2 py-2 bg-green-500 text-white rounded text-center hover:bg-green-600 transition">
                        <Link to={`/novel/${novel?.metalTitle}/${novel?.id}/de-cu/add`}><FontAwesomeIcon icon={faPlus} className="mr-2"/>Tạo đề cử mới</Link>
                    </button>
                </div>
            </div>
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 ">
                    <p className="text-center font-bold">Danh sách đề cử truyện {novel?.name}</p>
                </h2>
                <ul>
                    {nomination.map((nomination) => (
                        <li key={nomination.id}>
                            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                            <h2 className="flex inline-block border-b-2 border-black mb-2 ">
                                <p className="text-center font-bold">
                                    <LazyLoadImage
                                        src={'/Images/default_avatar.jpg'}
                                        alt=""
                                        width={30}
                                        height={30}
                                    />
                                    {nomination.user.userName}
                                </p>
                            </h2>
                                <p className="mb-2">Mức độ đánh giá : {nomination.Rating} <FontAwesomeIcon icon= {faStar} className="ml-2" /></p>
                                <p>{nomination.content}</p>
                            </div>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    )
}

export default Nomination