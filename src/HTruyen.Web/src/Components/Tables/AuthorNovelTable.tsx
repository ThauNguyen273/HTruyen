import { useEffect, useState } from "react";
import { GetNovelByAuthorId, Novel } from "../../Services/Novels/NovelService";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faList, faPen, faPlus } from "@fortawesome/free-solid-svg-icons";
import { Link, useParams } from "react-router-dom";

const AuthorNovelTable: React.FC = () => {
    const statusType= [
        { label: 'Chờ Duyệt', value: 1},
        { label: 'Đã Duyệt', value: 2},
        { label: 'Từ Chối', value: 3},
    ];
    const {authorId} = useParams()
    const [novels, setNovels] = useState<Novel[]>([]);
    
    useEffect(() => {
        const fetchData = async () => {
          try {
            const novelsData = await GetNovelByAuthorId(authorId); 
            setNovels(novelsData);
          } catch (error) {
            console.error('Error fetching novels:', error);
          }
        };
    
        fetchData();
      }, []); 

        const getStatusLabel = (statusValue: number) => {
            const status = statusType.find((item) => item.value === statusValue);
            return status ? status.label : '';
        };

    return (
        <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
        <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
            <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                <tr>
                    <th scope="col" className="px-6 py-3">
                        Tên truyện
                    </th>
                    <th scope="col" className="px-6 py-3">
                        <p className="flex justify-center items-center">Sửa</p>
                    </th>
                    <th scope="col" className="px-6 py-3">
                        <p className="flex justify-center items-center">Quản lý chương</p>
                    </th>
                    <th scope="col" className="px-6 py-3">
                        <p className="flex justify-center items-center">Thêm chương</p>
                    </th>
                    <th scope="col" className="px-6 py-3">
                        <p className="flex justify-center items-center">Trạng thái</p>
                    </th>
                </tr>
            </thead>
            <tbody>
                {novels.map((novel, index) => (
                    <tr key={index} className={`odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700`}>
                        <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                            {novel.name}
                        </th>
                        <td className="px-6 py-4 ">
                            <Link to={`/manager/novel/edit/${novel.id}`} className="flex justify-center items-center">
                                <FontAwesomeIcon icon={faPen}/>
                            </Link>
                        </td>
                        <td className="px-6 py-4">
                            <Link to={`/manager/chapter/${novel.id}`} className="flex justify-center items-center">
                            <FontAwesomeIcon icon={faList}/>
                            </Link>
                        </td>
                        <td className="px-6 py-4">
                            <Link to={`/manager/novel/${novel.id}/create-chapter`} className="flex justify-center items-center">
                            <FontAwesomeIcon icon={faPlus}/>
                            </Link>
                        </td>
                        <td className="px-6 py-4 flex justify-center items-center">{getStatusLabel(novel.status)}</td>
                    </tr>
                ))}
            </tbody>
      </table>
    </div>
    )
}

export default AuthorNovelTable;