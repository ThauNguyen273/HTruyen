import { useEffect, useState } from "react";
import { LazyLoadImage } from "react-lazy-load-image-component"
import { GetNovel, Novel } from "../../../Services/Novels/NovelService";
import { useParams } from "react-router-dom";
import { AddNomination } from "../../../Services/Nominations/NominationService";

const CreateNomination: React.FC = () => {
    const typeNomination = [
        { label: 'Truyện này quá tệ', value: 1},
        { label: 'Truyện này dở', value: 2},
        { label: 'Truyện bình thường', value: 3},
        { label: 'Truyện hay', value: 4},
        { label: 'Truyện quá xuất sắc', value: 5},
    ];
    const {novelId, userId} = useParams<{novelId: string, userId: string}>()
    const [nomination, setNomination] = useState('');
    const [nomiContent, setNomiContent] = useState('')
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

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            
            await AddNomination({
                rating: Number(nomination),
                content: nomiContent,
                userId: userId, 
                novelId: novel?.id
            });
            
            setNomination('');
            setNomiContent('');
            
        } catch (error) {
            console.log("Error adding nomination:", error);
        }
    };

    return (
        <div className="nomination-content p-4">
            <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                <h2 className="flex inline-block border-b-2 border-black mb-2 ">
                    <p className="text-center font-bold">Gửi ý kiến đánh giá của bạn để truyện có thể được nhiều người biết hơn nhé</p>
                </h2>
                <div className="mb-2">
                    <LazyLoadImage
                        src={'/Images/default_avatar.jpg'}
                        alt=""
                        width={30}
                        height={30}
                    />
                </div>
                <form onSubmit={handleSubmit}>
                    <div>
                        <div className="form-group mb-2">
                            <label htmlFor="novel-type" className="col-sm-2 px-2">Lựa chọn đánh giá</label>
                            <select
                                name="novelType"
                                value={nomination}
                                onChange={(e) => setNomination(e.target.value)}
                                className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                                required
                            >
                                <option value="" aria-disabled hidden>Chọn loại truyện</option>
                                {typeNomination.map((typeNomination, index) => (
                                    <option key={index} value={typeNomination.value}>
                                        {typeNomination.label}
                                    </option>
                                ))}
                            </select>
                        </div>
                    </div>
                    <div className="form-group mb-2">
                        <label htmlFor="novel-name" className="col-sm-2 px-2">Nội dung đánh giá</label>
                        <textarea
                            placeholder="Nhập đánh giá"
                            name="novel-description"
                            value={nomiContent}
                            onChange={(e) => setNomiContent(e.target.value)}
                            className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            required
                        />
                    </div>
                    <div className="form-group mb-2 text-center">
                        <button
                            type="submit"
                            className="mx-auto px-2 p-2 mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                        >Gửi Đề Cử</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default CreateNomination