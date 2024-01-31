import { useEffect, useState } from "react";
import { Chapter, GetByNovelId } from "../../Services/Chapters/ChapterService";
import { useParams } from "react-router-dom";

interface ChapterSelectprops {
    selectedChapter: string | null;
    onChapterChange: (value: string | null) => void;
}

const ChapterSelect: React.FC<ChapterSelectprops> = ({selectedChapter, onChapterChange}) => {
    const {novelId} = useParams<{novelId: string}>()
    const [chapters, setChapters] = useState<Chapter[]>([])

    useEffect(() => {
        const fetchChapters = async () => {
          try {
            const chaptersData = await GetByNovelId(novelId || '');
            if (chaptersData) {
              setChapters(chaptersData);
            } else {
            }
          } catch (error) {
            console.error('Error fetching chapters:', error);
          }
        };
    
        fetchChapters();
      }, []);


    return (
        <select
            name="novelChapter"
            value={selectedChapter || ""}
            onChange={(e) => onChapterChange(e.target.value || null)}
            className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
        >
            <option value="" disabled hidden>
                Chọn chương truyện
            </option>
            {chapters.map((chapter) => (
                <option key={chapter.id} value={chapter.id}>
                    {chapter.name}
                </option>
            ))}
        </select>
    )
}

export default ChapterSelect