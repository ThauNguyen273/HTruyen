import { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEye, faPen, faTrash, faUpload } from "@fortawesome/free-solid-svg-icons";
import { Link, useParams } from "react-router-dom";
import { Chapter, GetByNovelId, PostChapter } from "../../Services/Chapters/ChapterService";

const AuthorChapterTable: React.FC = () => {
    const statusType= [
        { label: 'Nháp', value: 0},
        { label: 'Đã Đăng', value: 1}
    ];
    const {novelId} = useParams<{novelId?: string}>()
    const [chapters, setChapters] = useState<Chapter[]>([]) 

    const getStatusLabel = (statusValue: number) => {
        const status = statusType.find((item) => item.value === statusValue);
        return status ? status.label : '';
    };

    useEffect(() => {
        const fetchChapters = async () => {
            try {
                const chaptersData = await GetByNovelId(novelId || '');
                if (chaptersData) {
                  setChapters(chaptersData);
                }
            } catch (error) {
                console.error('Error fetching chapters:', error);
            }
        };
        
            fetchChapters();
        }, [novelId]);

        const handlePublishChapter = async (chapterId: string) => {
        try {
            await PostChapter(chapterId, { chapterStatus: 1 });
            const updatedChapters = chapters.map((chapter) =>
                chapter.id === chapterId ? { ...chapter, chapterStatus: 1 } : chapter
            );
            setChapters(updatedChapters);
        } catch (error) {
            console.error('Error publishing chapter:', error);
        }
    };

    return (
        <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
            <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                    <tr>
                        <th scope="col" className="px-6 py-3">
                            Tên chương
                        </th>
                        <th scope="col" className="px-6 py-3">
                            <p className="flex justify-center items-center">Xem</p>
                        </th>
                        <th scope="col" className="px-6 py-3">
                            <p className="flex justify-center items-center">Sửa</p>
                        </th>
                        <th scope="col" className="px-6 py-3">
                            <p className="flex justify-center items-center">Xóa</p>
                        </th>
                        <th scope="col" className="px-6 py-3">
                            <p className="flex justify-center items-center">Đăng</p>
                        </th>
                        <th scope="col" className="px-6 py-3">
                            <p className="flex justify-center items-center">Trạng thái</p>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {chapters.map((chapter, index) => (
                        <tr
                            key={index}
                            className={`odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700`}
                        >
                            <th
                                scope="row"
                                className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white"
                            >
                                {chapter.name}
                            </th>
                            <td className="px-6 py-4">
                                <Link
                                    to={`/novel/${novelId}`}
                                    className="flex justify-center items-center"
                                >
                                    <FontAwesomeIcon icon={faEye} />
                                </Link>
                            </td>
                            <td className="px-6 py-4">
                                <Link
                                    to={`/manager/chapter/edit/${chapter.id}`}
                                    className="flex justify-center items-center"
                                >
                                    <FontAwesomeIcon icon={faPen} />
                                </Link>
                            </td>
                            <td className="px-6 py-4">
                                <Link
                                    to={`/manager/chapter/delete/${chapter.id}`}
                                    className="flex justify-center items-center"
                                >
                                    <FontAwesomeIcon icon={faTrash} />
                                </Link>
                            </td>
                            <td className="px-6 py-4">
                                <button
                                    onClick={() => handlePublishChapter(chapter.id)}
                                    className="flex justify-center items-center"
                                >
                                    <FontAwesomeIcon icon={faUpload} />
                                </button>
                            </td>
                            <td className="px-6 py-4 flex justify-center items-center">
                                {getStatusLabel(chapter.chapterStatus)}
                            </td>
                        </tr>
                    ))} 
                </tbody>
        </table>
    </div>
    )
}

export default AuthorChapterTable;