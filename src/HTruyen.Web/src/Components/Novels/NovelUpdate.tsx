import React ,{ useEffect, useState } from "react";
import { GetNovelNewUpdate, Novel, NovelSearchNewUpdate } from "../../Services/Novels/NovelService";
import NovelList from "./NovelList";

const NovelUpdate: React.FC = () => {
    const [novels, setNovels] = useState<Novel[]>([]);

    useEffect(() => {
        const fetchNovels = async () => {
          try {

            const searchCriteria: NovelSearchNewUpdate = {
              status: 2,
              pageNumber: 1,
              pageSize: 8,
            };
    
            const resultNovels = await GetNovelNewUpdate(searchCriteria);
    
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

export default NovelUpdate;