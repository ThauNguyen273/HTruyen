import CategoriesGrid from "../../Components/Grid/CategoriesGrid";

const Category: React.FC = () => {
    return (
        <div className="category-content p-2">
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 ">
                    <p className="text-center font-bold">Thể Loại Truyện</p>
                </h2>
                <p> Dưới đây là danh sách tổng hợp tất cả các thể loại truyện của HTruyen</p>
            </div>
            {/* Function */}
            <div className="w-full flex justify-center">
                <div className="w-full rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                    <CategoriesGrid/>
                </div>    
            </div>
        </div>
    );
};

export default Category;