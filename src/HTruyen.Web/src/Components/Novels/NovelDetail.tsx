import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { 
    faBook, 
    faCircleInfo, 
    faCircleUser, 
    faComments, 
    faStar } from "@fortawesome/free-solid-svg-icons";
import { Link, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { GetNovel, Novel } from "../../Services/Novels/NovelService";
import moment from "moment";
import { GetCountByNovel } from "../../Services/Chapters/ChapterService";
import LazyLoadImage from "../Loading/LazyLoadImage";

const NovelDetail: React.FC = () => {
    const statusType= [
        { label: 'Đang Ra', value: 1},
        { label: 'Hoàn Thành', value: 2},
        { label: 'Drop', value: 3},
    ];
    const novelType= [
        { label: 'Dịch', value: 1},
        { label: 'Convert', value: 2},
        { label: 'Sáng Tác', value: 3},
    ];
    const {novelId} = useParams<{novelId: string, userId: string}>()
    const [novel, setNovel] = useState<Novel | null>(null)
    const [chapterCount, setChapterCount] = useState<number | null>(null)

    const getStatusLabel = (statusValue?: number) => {
        const status = statusType.find((item) => item.value === statusValue);
        return status ? status.label : '';
    };
    const getTypeNovelLabel = (statusValue?: number) => {
        const status = novelType.find((item) => item.value === statusValue);
        return status ? status.label : '';
    };

    useEffect(() => {
        const fetchNovel = async () => {
            try {
                const fetchNovel = await GetNovel(novelId)
                setNovel(fetchNovel)
            } catch (error) {
                console.log("Error fetching novel")
            }
        }

        const fetchChapterCount = async () => {
            try {
                const count = await GetCountByNovel({novelId, chapterStatus: 1})
                setChapterCount(count)
            } catch (error) {
                console.log("Error fetching chapter count:", error)
            }
        }

        fetchNovel()
        fetchChapterCount()
    },[novelId])

    

    return (
        <div className="chapter-content p-2">
            <div className="w-full p-4 mb-2 rounded overflow-hidden border-gray-300 dark:bg-gray dark:bg-gray-300">
                <div className="flex items-center justify-between">
                    <Link to={``} className="flex flex-col items-center">
                        <FontAwesomeIcon icon={faBook} className="mb-1"/>
                        Truyện
                    </Link>
                    <Link to={`/novel/${novel?.metalTitle}/${novel?.id}/de-cu`} className="flex flex-col items-center">
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
            <div className="w-full flex p-4 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <div>
                    <LazyLoadImage
                        src={'/Images/novel_default.png'}
                        alt=""
                        width={100}
                        height={150}
                    />
                </div>
                <div className="info">
                    <h1 className="title px-3 text-[15] font-semibold mb-2 leading-5 font-roboto-condensed font-bold tracking-tighter">
                        {novel?.name}
                    </h1>
                    <div className="alt-name mb-1 flex items-center">
                        <i className="px-3 text-sm text-gray-500">
                            <FontAwesomeIcon icon={faCircleUser}/>
                        </i>
                        <a href="" className="text-sm text-gray-500">{novel?.author.authorName}</a>
                    </div>
                    <div className="px-3 mt-10 flex space-x-2">
                        <a href="" className="text-xs rounded-full border border-gray-300 p-1 badge bg-blue-500 text-white">{getTypeNovelLabel(novel?.categoryOT)}</a>
                    </div>
                </div>
            </div>
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <div className="w-full flex p-2 mb-2 rounded overflow-hidden">
                        <button className="flex-1 mr-2 px-2 py-2 bg-blue-500 text-white rounded text-center hover:bg-blue-600 transition">
                            <Link to={``}>Đọc Từ Đầu</Link>
                        </button>
                        <button className="flex-1 ml-2 px-2 py-2 bg-blue-500 text-white rounded text-center hover:bg-blue-600 transition">
                            <Link to={``}> DS.Chương</Link>
                        </button>
                </div>
                <div className="w-full flex justtify-bes p-2 mb-2 rounded overflow-hidden">
                    <button className="flex-1 mr-2 px-2 py-2 bg-green-500 text-white rounded text-center hover:bg-green-600 transition">
                        <Link to={`/novel/${novel?.metalTitle}/${novel?.id}/de-cu`}>Review</Link>
                    </button>
                    <></>
                    <button className="flex-1 ml-2 px-2 py-2 bg-green-500 text-white rounded text-center hover:bg-green-600 transition">
                        <Link to={``}>Thêm vào tủ sách</Link>
                    </button>
                </div>
            </div>
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <table className="table-fixed">
                    <tbody>
                        <tr>
                            <td>Thể loại</td>
                            <td>
                                <a href="#" className="p-4">{novel?.metalTitle}</a>
                            </td>
                        </tr>
                        <tr>
                            <td>Trạng thái</td>
                            <td>
                                <a href="#" className="p-4">{getStatusLabel(novel?.novelST)}</a>
                            </td>
                        </tr>
                        <tr>
                            <td>Số chương</td>
                            <td>
                                <a className="p-4">{chapterCount?.toString()}</a>
                            </td>
                        </tr>
                        <tr>
                            <td>Cập nhật</td>
                            <td><time className="p-4" >{`${moment(novel?.dateUpdated).fromNow()}`}</time></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 ">
                    <p className="text-center font-bold">Giới Thiệu Truyện {novel?.name} </p>
                </h2>
                <div>
                    <article 
                        className="pre-wrap"
                        style={{
                            fontFamily: "sans-serif",
                            fontSize: 18,
                            lineHeight: "1.3",
                            overflowWrap: "break-word",
                            wordWrap: "break-word",
                            whiteSpace: "pre-wrap"
                        }}> 
                            {novel?.description ? (
                                <>{novel?.description}</>
                            ) : (
                                <span>No description available</span>
                            )}                  
                    </article>
                </div>
            </div>
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 ">
                    <p className="text-center">Chương mới nhất {novel?.name}</p>

                </h2>
            </div>
        </div>
    );
};

export default NovelDetail;