import { useEffect, useState } from "react";
import { Category, GetList } from "../../Services/Categories/CategoryService";

interface CategorySelectprops {
    selectedCategory: string;
    onCategoryChange: (value: string) => void;
}

const CategorySelect: React.FC<CategorySelectprops> = ({ selectedCategory, onCategoryChange}) => {
    const [categories, setCategories] = useState<Category[]>([])

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const categoriesData = await GetList();
                setCategories(categoriesData)
            } catch (error) {
                throw error;
            }
        }

        fetchCategories()
    }, [])

    return (
        <select
            name="novelCategory"
            value={selectedCategory}
            onChange={(e) => onCategoryChange(e.target.value)}
            className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
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
    )
}

export default CategorySelect;