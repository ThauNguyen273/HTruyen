import { faCircleUser } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const NovelInfo: React.FC = () =>{
    return(
        <div className="novel-content">
            <div className="novel-detail">
                <div className="info-zone box-border p-2 pb-5 flex">
                    <div className="novel-cover">
                        <img data-srcset="public\Images\default_novel.png"
                             data-sizes="auto"
                             alt=""
                             width="80"
                             height="120"
                             className="lazy"
                             loading="lazy"/>
                    </div>
                    <div className="info">
                        <h1 className="title px-3 text-[15] font-semibold mb-2 leading-5 font-roboto-condensed font-bold tracking-tighter">Cày Tại Tận Thế Thêm Điểm Thăng Cấp (Bản Dịch)</h1>
                        <div className="alt-name mb-1 flex items-center">
                            <i className="px-3 text-sm  text-gray-500"><FontAwesomeIcon icon={faCircleUser}/></i>
                            <a href="" className="text-sm text-gray-500">Tân Phong</a>
                        </div>
                        <div className="px-3 mt-1 flex space-x-2">
                            <a href="#" className="text-xs rounded-full border border-gray-300 p-1 badge bg-red-500 text-white justify-between">Truyện VIP</a>
                            <a href="#" className="text-xs rounded-full border border-gray-300 p-1 badge bg-blue-500 text-white">Dịch</a>
                        </div>
                    </div>
                </div>
                <div id="root_novel_buttons" className="mt-2">
                    <div className="buttons flex p-2 text-center justify-center">
                        <a href="#" className="flex-grow bg-blue-500 text-white py-1 px-2 rounded-md text-sm">Đọc Từ Đầu</a>
                        <div className="w-2"></div>
                        <a href="#" className="flex-grow bg-gray-300 text-gray-700 py-1 px-2 rounded-md text-sm">Lưu Tủ Sách</a>
                        
                    </div>
                    <div className="buttons flex p-2 text-center justify-center">
                        <a href="#" className="flex-grow bg-yellow-500 text-white py-1 px-2 rounded-md text-sm">Mua Chương Vip</a>
                        <div className="w-2"></div>
                        <a href="#" className="flex-grow bg-gray-300 text-gray-700 py-1 px-2 rounded-md text-sm">Danh Sách Chương</a>
                    </div>
                </div>
                <div className="novel-metal p-2 mb-2">
                    <table className="table-fixed">
                        <tbody>
                            <tr>
                                <td>Thể loại</td>
                                <td>
                                    <a href="#" className="p-2">Huyền Huyễn</a>
                                </td>
                            </tr>
                            <tr>
                                <td>Trạng thái</td>
                                <td>
                                    <a href="#" className="p-2">Còn Tiếp</a>
                                </td>
                            </tr>
                            <tr>
                                <td>Số chương</td>
                                <td>
                                    <a className="p-2">52</a>
                                </td>
                            </tr>
                            <tr>
                                <td>Cập nhật</td>
                                <td><time className="p-2" dateTime="2023-12-21T09:15:05.354057+07:00">4 tiếng</time></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <article className="novel-about boder-x-4 border border-b-slate-300 mb-2 p-2">
                    <h2 className="novel-title px-2 bg-gray-200 p-1 border border-slate-300">Giới Thiệu Truyện Cày Tại Tận Thế Thêm Điểm Thăng Cấp (Bản Dịch)</h2>
                    <div className="novel-content">
                        <div></div>
                        <div className="novel-summary-more more">
                            <div id="summary_markdown">
                                <div className="px-2">
                                    <p>Lâm Phàm xuyên không.</p>
                                    <p>Xuyên qua thế giới xa lạ trước thời điểm bộc phát tai thú 10 năm.</p>
                                    <p>Trật tự sụp đổ, nhân loại kéo dài hơi tàn.</p>
                                    <p>Người người đều nói dị thú đáng sợ nhất, nhưng theo Lâm Phàm, người sống sót còn sống càng thêm đáng sợ.</p>
                                    <p>Lâm Phàm: Ta không phục, cho ta lá gan, cho ta thêm điểm, ta muốn rèn đúc văn minh thế giới.</p>
                                    <p>Hắn muốn trở thành ánh sáng trong lòng đám nhân loại kia, để bọn hắn nhìn thấy ánh nắng, liền sẽ nhớ tới Lâm Phàm hắn</p>
                                </div>
                            </div>    
                        </div>
                    </div>
                </article>
                <div id="root_novel_numbers" className="mt-2 flex p-2 text-center justify-center">
                    <div className="novelMetaNumbers">
                        <div className="numbers flex">
                            <div className="box-item px-4 mr-6 border border-gray-200">
                                <strong className="block">2</strong>
                                <span className="block">thích</span>
                            </div>
                            <div className="box-item px-4 mr-6 border border-gray-200">
                                <strong className="block">402</strong>
                                <span className="block">đọc</span>
                            </div>
                            <div className="box-item px-4 mr-6 border border-gray-200">
                                <strong className="block">2</strong>
                                <span className="block">bình</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="weui-cells mt-2 ">
                    <h2 className="cell-header text-gray-400 px-2 ">Chương Mới Nhất Cày Tại Tận Thế Thêm Điểm Thăng Cấp (Bản Dịch)</h2>
                    <a href="#" className="weui-cell weui-cell_access flex p-2">
                        <div className="weui-cell__hd">
                            <img src="https://yystatic.codeprime.net/svg/vip.svg" alt="" width="18" height="18" className="lazy mr-2 loaded" />
                        </div>
                        <div className="weui-cell__bd weui-cell_primary">
                            <div className="">Phụ ma. (2)</div>
                            <div className="small text-success ">
                                <time className="timeago text-[10px] text-green-400" dateTime="2023-12-21T09:15:05.317000+07:00">4 tiếng</time>
                            </div>
                        </div>
                        <div className="weui-cell__ft px-20 ">Ch.52</div>
                    </a>
                </div>
            </div>
        </div>
    )
}

export default NovelInfo;