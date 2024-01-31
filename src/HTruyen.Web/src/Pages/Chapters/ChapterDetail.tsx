import { useEffect, useState } from "react";
import { Chapter, GetByStatus } from "../../Services/Chapters/ChapterService";
import CryptoJS from "crypto-js"

interface ChapterDetailProps {
    chapterId: string;
  }

const ChapterDetail: React.FC<ChapterDetailProps> = ({chapterId}) => {
    const [selectedChapter, setSelectedChapter] = useState<Chapter | null>(null);

    const decryptContent = (encryptedContent: string): string => {
        const key = CryptoJS.enc.Utf8.parse("$2a$11$49ScwBrYey8JD.0AFL0Xku4lZf.pajO1vIb7QF4gopfkqAIFIk3DK");
        const iv = CryptoJS.enc.Utf8.parse("2a$11$MBPVyed0AGbXFnkTovRjWewm8.rOA2mKOVldK0BfbLtE6pifbFvdW");

        const decrypted = CryptoJS.AES.decrypt(encryptedContent, key, {
            iv: iv,
            mode: CryptoJS.mode.CBC,
            padding: CryptoJS.pad.Pkcs7,
        });

        return CryptoJS.enc.Utf8.stringify(decrypted);
    };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const chapter = await GetByStatus({ chapterId, status: 1 });
        const decryptedChapter = {
          ...chapter,
          content: decryptContent(chapter.content),
        };

        setSelectedChapter(decryptedChapter);
      } catch (error) {
        console.error("Error fetching chapter:", error);
      }
    };

    fetchData();
  }, [chapterId]);


    return (
        <>
            <div className="mb-4 text-xl font-bold">
                {selectedChapter?.name}
            </div>
            <div>
                <pre className="pre-wrap"
                    style={{
                        fontFamily: "sans-serif",
                        fontSize: 18,
                        lineHeight: "1.3",
                        overflowWrap: "break-word",
                        wordWrap: "break-word",
                        whiteSpace: "pre-wrap"
                    }}
                >
                    {selectedChapter?.content}
                </pre>
            </div>
        </>
    )
}

export default ChapterDetail