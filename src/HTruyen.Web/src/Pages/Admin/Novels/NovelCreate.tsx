import { faCloudArrowUp } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";
import { GetList, Category } from "../../../Services/Categories/CategoryService";

const NovelCreate: React.FC = () => {
    const novelType = [
        { label: 'Dịch', value: 1},
        { label: 'Convert', value: 2},
        { label: 'Sáng Tác', value: 3},
    ];

    const [categories, setCategories] = useState<Category[]>([]);
    const [selectedCategory, setSelectedCategory] = useState<string>('');

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const categoriesData = await GetList();
                setCategories(categoriesData);
            } catch (error) {
                throw error;
            }
        }

        fetchCategories();
    }, []);

    return (
        <div className="novel-content p-2">
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold items-center text-xl	">
                    <FontAwesomeIcon icon={faCloudArrowUp} className="px-2"/>
                    Đăng truyện
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
                        className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
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
                        className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                    >
                        <option value="" aria-disabled hidden>
                            Chọn loại truyện
                        </option>
                        {novelType.map((noveltype, index) => (
                            <option key={index} value={noveltype.value}>
                                {noveltype.label}
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
                    <select
                        name="novelCategory"
                        value={selectedCategory}
                        onChange={(e) => setSelectedCategory(e.target.value)}
                        className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                    >
                        <option value="" disabled hidden>
                            Chọn thể loại truyện
                        </option>
                        {categories.map((category) => (
                            <option key={category.id} value={category.id}>
                                {category.name}
                            </option>
                        ))}
                    </select>
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
                        className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                    />
                </div>
                <div className="form-group mb-2 text-center">
                    <button
                        
                        className="mx-auto px-2 p-2 mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                        >Tạo Truyện</button>
                </div>
            </div>
        </div>
    )
}

export default NovelCreate;