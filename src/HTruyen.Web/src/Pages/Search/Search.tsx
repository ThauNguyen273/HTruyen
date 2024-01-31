import { useEffect, useState } from "react";
import { Category, GetList } from "../../Services/Categories/CategoryService";
import { Novel, NovelSearchMany, SearchAdvanced } from "../../Services/Novels/NovelService";

const Search: React.FC = () => {
    const novelType = [
        { label: 'Dịch', value: 1},
        { label: 'Convert', value: 2},
        { label: 'Sáng Tác', value: 3},
    ];

    const novelSType = [
        { label: 'Còn Tiếp', value: 1},
        { label: 'Hoàn Thành', value: 2},
        { label: 'Drop', value: 3}
    ];

    const [categories, setCategories] = useState<Category[]>([]);
    const [selectedCategory, setSelectedCategory] = useState<string>('');
    const [searchResults, setSearchResults] = useState<Novel[]>([]);

    const [searchParams, setSearchParams] = useState<NovelSearchMany>({
        status: 2,
        pageNumber: 1,
        pageSize: 15,
      });

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

    const handleSearch = async () => {
        try {
            const params: NovelSearchMany = {
                name: searchParams.name,
                categoryId: selectedCategory,
                novelStatusType: searchParams.novelStatusType,
                status: 2,
                pageNumber: 1,
                pageSize: 15,
            }

            const results = await SearchAdvanced(params);
            setSearchResults(results)
        } catch (error) {
            console.error('Error searching novels:', error)
        }
    }

    

    return (
        <div className="search-content p-2">
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 ">
                    <p className="text-center font-bold">Tìm Kiếm Truyện</p>
                </h2> 
            </div>

            {/* Function */}
            <div className="w-full flex justify-center mb-2">
                <div className="w-full rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                    <div className="form-group mb-2 px-2 mt-2">
                        <label
                            htmlFor="novel-name" 
                            className="col-sm-2 px-2">
                            Theo Tên Truyện
                        </label>
                        <input
                            placeholder="Nhập tên truyện"
                            type="text"
                            name="name"
                            onChange={(e) => setSearchParams({ ...searchParams, name: e.target.value })}
                            className="p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                        />
                    </div>
                    <div className="form-group mb-2 px-2">
                        <label
                            htmlFor="novel-category" 
                            className="col-sm-2 px-2">
                            Theo Thể Loại Truyện
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
                    <div className="form-group mb-2 px-2">
                        <label
                            htmlFor="novel-type" 
                            className="col-sm-2 px-2">
                            Theo Loại truyện
                        </label>
                        <select
                            name="novelType"
                            className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                        >
                            <option value="" aria-disabled hidden>
                                Chọn Loại Truyện
                            </option>
                            {novelType.map((noveltype, index) => (
                                <option key={index} value={noveltype.value}>
                                    {noveltype.label}
                                </option>
                            ))}
                        </select> 
                    </div>
                    <div className="form-group mb-2 px-2">
                        <label
                            htmlFor="novel-type" 
                            className="col-sm-2 px-2">
                            Theo Tình Trạng Truyện
                        </label>
                        <select
                            name="novelType"
                            className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                        >
                            <option value="" aria-disabled hidden>
                                Chọn Loại Tình Trạng Truyện
                            </option>
                            {novelSType.map((novelstype, index) => (
                                <option key={index} value={novelstype.value}>
                                    {novelstype.label}
                                </option>
                            ))}
                        </select> 
                    </div>
                    <div className="form-group mt-2 px-2">
                        <div className="form-group mt-2 mb-2 text-center">
                            <button 
                                onClick={handleSearch} 
                                className="mx-auto px-4 p-2 mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            >Tìm Kiếm</button>
                        </div>
                    </div>
                </div>    
            </div>
            <div className="w-full flex justify-center">
                <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                    <div className="w-full rounded overflow-hidden border border-solid border-gray-400 dark:border-gray-200">
                        <h2 className="flex inline-block border-b-2 border-black mb-2 ">Kết Quả Tìm Kiếm</h2>
                        <div className=" px-2 flex flex-col rounded border border-solid border-gray-100">
                            {searchResults.map((novel) => (
                                <div key={novel.id} className="border p-4 mb-1">
                                    <a href={`/novel/${novel.metalTitle}/${novel.id}`}>
                                        <h2 className="text-xl font-bold">{novel.name}</h2>
                                        <h3 className="text-sm text-gray-500 mb-1">{novel.author.authorName}</h3>
                                    </a>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>
            </div>    
        </div>
    );
};

export default Search;