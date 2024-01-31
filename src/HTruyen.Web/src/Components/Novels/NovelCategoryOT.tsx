import { useEffect, useState } from "react";
import { GetNovelByCategoryOT, Novel, NovelSearchCategoryOT } from "../../Services/Novels/NovelService";
import NovelList from "./NovelList";

const NovelCategoryOT: React.FC = () => {
    const [novels, setNovels] = useState<Novel[]>([]);

    useEffect(() => {
        const fetchNovels = async () => {
          try {

            const searchCriteria: NovelSearchCategoryOT = {
              categoryOfType: 1,
              status: 2,
              pageNumber: 1,
              pageSize: 8,
            };
    
            const resultNovels = await GetNovelByCategoryOT(searchCriteria);
    
            setNovels(resultNovels);
          } catch (error) {
            console.error('Error fetching novels:', error);
          }
        };
    
        fetchNovels();
      }, []);
    
      return (
        <div>
            <NovelList novels={novels}/>
        </div>
      )
}

export default NovelCategoryOT;