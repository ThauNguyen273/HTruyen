import { faCloudArrowUp } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";
import CategorySelect from "../../../Components/Categories/CategorySelect";
import { CreateNovel, GetNovel } from "../../../Services/Novels/NovelService";
import NotificationSuccess from "../../../Components/Notification/NotificationSuccess";
import { useParams } from "react-router-dom";

const EditNovel: React.FC = () => {
    const {authorId, novelId} = useParams<{ authorId?: string; novelId?: string }>();
    const typeNovel = [
        { label: 'Dịch', value: 1},
        { label: 'Convert', value: 2},
        { label: 'Sáng Tác', value: 3},
    ];

    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [selectedCategory, setSelectedCategory] = useState<string>('');
    const [novelName, setNovelName] = useState('');
    const [tqName, setTqName] = useState('');
    const [tqUrl, setTqUrl] = useState('');
    const [novelType, setNovelType] = useState('');
    const [novelDescription, setNovelDescription] = useState('');

    useEffect(() => {
        const fetchData = async () => {
            try {
                if (novelId) {
                    const novelData = await GetNovel(novelId);
                    setNovelName(novelData.name);
                    setTqName(novelData && novelData.tqName ? novelData.tqName : '');
                    setTqUrl(novelData && novelData.tqUrl ? novelData.tqUrl : '');
                    setNovelType(novelData.categoryOT.toString());
                    setSelectedCategory(novelData && novelData.categoryId ? novelData.categoryId : '');
                    setNovelDescription((novelData && typeof novelData.description === 'string') ? novelData.description : '');
                }
            } catch (error) {
                console.error('Error fetching novel:', error);
            }
        };

        fetchData();
    }, [novelId]);


    const handleCreateNovel = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {

            const categoryOTMap: {[key: string]: number } = {1: 1, 2: 2, 3: 3}

            const novelParams = {
                authorId: authorId,
                categoryId: selectedCategory,
                name: novelName,
                tqName : tqName,
                tqUrl: tqUrl,
                description: novelDescription,
                categoryOT: categoryOTMap[novelType],
                novelST: 1,
                status: 1,
                dateCreated: new Date().toISOString()
            }

            await CreateNovel(novelParams);

            setSuccessMessage("Truyện đã được tạo thành công!");
            window.location.reload();
        } catch (error) {
            console.error('Error creating novel', error)
        }
    }

    const closeNotification = () => {
        setSuccessMessage(null);
      };

    return (
        <div className="novel-content p-2">
            {successMessage && (
                <NotificationSuccess message={successMessage} onClose={closeNotification} />
            )}
            <form onSubmit={handleCreateNovel}>
                <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                    <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold items-center text-xl	">
                        <FontAwesomeIcon icon={faCloudArrowUp} className="px-2"/>
                        Cập Nhật Truyện
                    </h2>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-name" 
                            className="col-sm-2 px-2">
                            Tên truyện
                        </label>
                        <input
                            placeholder="Nhập tên truyện"
                            type="text"
                            name="name"
                            value={novelName}
                            onChange={(e) => setNovelName(e.target.value)}
                            className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            required
                        />
                    </div>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-tqName" 
                            className="col-sm-2 px-2">
                            Tên tiếng trung
                        </label>
                        <input
                            placeholder="Nhập tên tiếng trung"
                            type="text"
                            name="name"
                            value={tqName}
                            onChange={(e) => setTqName(e.target.value)}
                            className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                        />
                    </div>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-name" 
                            className="col-sm-2 px-2">
                            Link tiếng trung
                        </label>
                        <input
                            placeholder="Nhập link tiếng trung"
                            type="text"
                            name="name"
                            value={tqUrl}
                            onChange={(e) => setTqUrl(e.target.value)}
                            className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                        />
                    </div>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-type" 
                            className="col-sm-2 px-2">
                            Loại truyện
                        </label>
                        <select
                            name="novelType"
                            value={novelType}
                            onChange={(e) => setNovelType(e.target.value)}
                            className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            required
                        >
                            <option value="" aria-disabled hidden>
                                Chọn loại truyện
                            </option>
                            {typeNovel.map((typeNovel, index) => (
                                <option key={index} value={typeNovel.value}>
                                    {typeNovel.label}
                                </option>
                            ))}
                        </select> 
                    </div>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-category" 
                            className="col-sm-2 px-2">
                            Thể loại
                        </label>
                        <CategorySelect
                            selectedCategory={selectedCategory}
                            onCategoryChange={(value) => setSelectedCategory(value)}
                        />
                    </div>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-image"
                            className="col-sm-2 px-2"
                        >
                            Ảnh truyện
                        </label>
                        <input
                            type="file"
                            accept="image/*"
                            name="novelImage"
                            className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                        />
                    </div>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-name" 
                            className="col-sm-2 px-2">
                            Giới thiệu
                        </label>
                        <textarea
                            placeholder="Nhập giới thiệu"
                            name="novel-description"
                            value={novelDescription}
                            onChange={(e) => setNovelDescription(e.target.value)}
                            className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            required
                        />
                    </div>
                    <div className="form-group mb-2 text-center">
                        <button
                            type="submit"
                            className="mx-auto px-2 p-2 mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            >Cập Nhật</button>
                    </div>
                </div>
            </form>
        </div>
    )
}

export default EditNovel;