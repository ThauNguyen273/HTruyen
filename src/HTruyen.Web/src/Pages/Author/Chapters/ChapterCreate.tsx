import { faTicket } from "@fortawesome/free-solid-svg-icons";
import NotificationSuccess from "../../../Components/Notification/NotificationSuccess"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";
import { useParams } from "react-router-dom";
import { CreateChapter } from "../../../Services/Chapters/ChapterService";
import CryptoJS from "crypto-js"

const ChapterCreate: React.FC = () => {
    const { novelId } = useParams<{ novelId: string }>();

    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [chapterName, setChapterName] = useState('')
    const [chapterNumber, setChapterNumber] = useState('')
    const [chapterContent, setChapterContent] = useState('')

    const encryptContent = (content: string): string => {
        const key = CryptoJS.enc.Utf8.parse("$2a$11$49ScwBrYey8JD.0AFL0Xku4lZf.pajO1vIb7QF4gopfkqAIFIk3DK");
        const iv = CryptoJS.enc.Utf8.parse("2a$11$MBPVyed0AGbXFnkTovRjWewm8.rOA2mKOVldK0BfbLtE6pifbFvdW");

        const encrypted = CryptoJS.AES.encrypt(content, key, {
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7,
        });

        return encrypted.toString();
    };

    const handleCreateChapter = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const encryptedContent = encryptContent(chapterContent)

            const chapterParams = {
                novelId: novelId,
                chapterNumber: chapterNumber,
                name: chapterName,
                content: encryptedContent,
                dateCreated: new Date().toISOString()
            }

            await CreateChapter(chapterParams)

            setSuccessMessage("Thêm chương thành công!")            
            window.location.reload();
        } catch (error) {
            console.error('Error creating chapter:', error);
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
            <form onSubmit={handleCreateChapter}>
                <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
                    <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold items-center text-xl	">
                        <FontAwesomeIcon icon={faTicket} className="px-2"/>
                        Thêm chương
                    </h2>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-name" 
                            className="col-sm-2 px-2">
                            Số chương
                        </label>
                        <input
                            placeholder="Nhập số chương"
                            type="text"
                            name="name"
                            value={chapterNumber}
                            onChange={(e) => setChapterNumber(e.target.value)}
                            className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            required
                        />
                    </div>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-name" 
                            className="col-sm-2 px-2">
                            Tên chương
                        </label>
                        <input
                            placeholder="Nhập tên chương. Ví dụ: Chương 1: ..."
                            type="text"
                            name="name"
                            value={chapterName}
                            onChange={(e) => setChapterName(e.target.value)}
                            className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            required
                        />
                    </div>
                    <div className="form-group mb-2">
                        <label
                            htmlFor="novel-name" 
                            className="col-sm-2 px-2">
                            Nội dung chương
                        </label>
                        <textarea
                            placeholder="Nhập nội dung"
                            name="chapter-content"
                            value={chapterContent}
                            onChange={(e) => setChapterContent(e.target.value)}
                            className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            required
                        />
                    </div>
                    <div className="form-group mb-2 text-center">
                        <button
                            type="submit"
                            className="mx-auto px-2 p-2 mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                            >Tạo chương</button>
                    </div>
                </div>
            </form>
        </div>
    )    
}

export default ChapterCreate