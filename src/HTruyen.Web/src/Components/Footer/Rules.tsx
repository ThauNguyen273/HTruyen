// Quy tắc của Website

const Rules: React.FC = () => {
    return(
        <div className="rules-content sticky left-0 right-0 m-b-10">

            <header className="sub-bar boder-y-1 bg-gray-200 p-1 border border-b-slate-300">
                <h1 className="text-black text-[15px] font-bold flex justify-center items-center">Quy Tắc Website</h1>
            </header>

            <h2 className="text-black text-[14px] font-thin px-3">Quy tắc của HTruyen khi cung cấp dịch vụ trên Internet</h2>

            <article className="content text-black text-[14px]">
                <p className="px-3 flex mb-2">Khi tham gia sử dụng dịch vụ cung cấp bởi<b className="px-1">HTruyen</b> , bạn phải đồng ý và tuân thủ các quy tắc sau.</p> 
                <p className="px-3 flex mb-2">Quy tắc này áp dụng cho mọi đối tượng tham gia hoạt động tại website, không kể là khách, thành viên, admin hay bất cứ chức danh nào khác.</p>
                <p className="px-3">Quy tắc này gồm 2 bên chính:</p>
                <ul className="px-6 list-disc">
                    <li>HTruyen cung cấp dịch vụ trên Internet.</li>
                    <li>Khách hàng gọi tắt là KH, sử dụng dịch vụ của HTruyen trên Internet.</li>
                </ul>
                <h3 className="mt-2 font-bold px-2">A. Các Quy Tắc Chung</h3>
                <ol className="px-8 list-decimal">
                    <li>Không bàn luận về tôn giáo và chính trị.</li>
                    <li>Tôn trọng pháp luật Việt Nam, tôn trọng văn hóa, lối sống và đạo đức của con người Việt Nam.</li>
                    <li>Truyện có nội dung người lớn phải gắn nhãn giới hạn độ tuổi phù hợp, ví dụ: 16+, 18+.</li>
                    <li>Htruyen có cảnh báo về giới hạn độ tuổi cũng như không khuyến khích người đọc chưa đủ tuổi truy cập các truyện 18+. Nếu người đọc vẫn cố vi phạm thì HTruyen không chịu bất cứ trách nhiệm nào trước pháp luật cũng như cá nhân nào đó.</li>
                    <li>Các thành viên nhỏ tuổi cố ý vượt qua các cảnh báo vè giới hạn độ tuổi không thuộc trách nhiệm của HTruyen.</li>
                    <li>Không đả kích, bêu xấu cá nhân và tổ chức trên HTruyen. Hãy cư xử có văn hóa, hòa nhã với nhau.</li>
                    <li>Không sử dụng các từ tục tĩu, ác đọc trực tiếp trên HTruyen mà phải sử dụng ký tự thay thế là dấu (*).</li>
                    <li>Quy định về mức phạt đối với thành viên vi phạm nội quy là do ban quản trị website tự đề ra.</li>
                    <li>Không spam tin nhắn, bình luận, bài viết hay bất cứ hình thức nào tại HTruyen.</li>
                    <li>Không để avatar tục tĩu, vi phạm pháp luật hoặc ảnh hưởng đến người khác.</li>
                    <li>Không tận dụng các bugs (lỗi) của chương trình nhằm phá hoại sự ổn định của HTruyen.</li>
                    <li>Sẽ khóa vĩnh viễn các tài khoản leak truyện VIP ra ngoài mà không được sự cho phép bằng văn bản của HTruyen.</li>
                    <li>HTruyen nghiêm cấm mua bán truyện ngoài luồng trên web và app của mình mà không thông qua các kênh chính thức.</li>
                    <li>Nghiêm cấm quảng cáo các website, ứng dụng khác trên tất cả các kênh của HTruyen.</li>
                    <li>Việc đăng ký tên tài khoản là số điện thoại, email và các thông tin nhạy cảm khác là bị cấm tại HTruyen.</li>
                    <li>Mọi hành động gây phương hại đến lợi ích của TruyenYY và cộng đồng sẽ bị block vĩnh viễn mà không cần báo trước.</li>
                    <li>Quy tắc có thể thay đổi tùy theo tình hình thực tế mà không cần báo trước.</li>
                </ol>
                <h3 className="mt-2 font-bold px-2">B. Quy Tắc Đăng Truyện </h3>
                <ol className="px-8 list-decimal">
                    <li>Truyện chưa có chương không được công bố.</li>
                    <li>Chỉ được phép đăng các truyện chữ hoặc các truyện có số lượng chữ trên 50%. Cấm đăng truyện tranh, video clip hoặc âm thanh.</li>
                    <li>Tên truyện phải được viết dưới dạng Titlecase (viết hoa đầu mỗi chữ): <b>Giống Như Thế Này.</b> </li>
                    <li>Nội dung chương phải trình bày đẹp, nếu có rác như câu cú lủng củng, từ sai lỗi chính tả quá nhiều, có đường link tới các trang web ngoài sẽ bị xóa.</li>
                    <li>Không được sử dụng các từ tục tĩu thiếu văn hóa. Nếu muốn dùng phải thay thế bằng dấu * hoặc dấu gạch ngang (-).</li>
                    <li>Văn bản trình bày phải phân đoạn rõ ràng, nếu viết thành 1 khối dày đặc chữ cũng không được đăng.</li>
                    <li>TruyenYY để phân biệt các kiểu dịch khác nhau, TruyenYY cho phép thêm vào tiêu đề truyện ví dụ như:<b> Đấu Phá Thương Khung (Dịch), Thiếu Gia Bị Bỏ Rơi (Convert)</b>.</li>
                    <li>Truyện có chương quá ngắn, dưới 1000 chữ mỗi chương không được công bố, trừ các thể loại đặc thù như ngôn tình, tản văn, thơ.</li>
                    <li>Truyện có nội dung sắc nặng không được phép đăng tại HTruyen. Nếu cố tình vi phạm, truyện sẽ bị xóa, thành viên truyện sẽ bị khóa và thu hồi tất cả tiền trong truyện cũng như tài khoản. Truyện được xem là sắc nặng nếu mô tả các bộ phận sinh dục của con người hoặc loài vật quá cụ thể chi tiết; mô tả cảnh quan hệ chi tiết và có tính kích dục cao.</li>
                    <li>Bìa truyện không được đưa các thông tin như chức năng của website, thể loại truyện, tính chất, tình tiết trong truyện.</li>
                    <li>Bìa truyện không có các hình ảnh khiêu dâm, kích dục, kích động, thù hằn, ám chỉ đến tôn giáo, chính trị, các hoạt động bị cấm bởi pháp luật.</li>
                    <li>Bìa truyện không được thêm bất cứ thông tin nào khác ngoài Tác giả, Tên truyện và Tên nhóm dịch.</li>
                    <li>Nghiêm cấm đặt thêm các thông tin như thông tin cá nhân, phương thức liên lạc, thông tin chuyển khoản, liên kết, tên website, tên nhóm dịch, các phương thức liên lạc... vào các thành phần trong truyện (ví dụ: nội dung chương, tên chương, tên truyện, tên tác giả, giới thiệu truyện, giới thiệu nhóm dịch, thông báo nhóm dịch, bình luận, đề cử...).</li>
                    <li>Truyện nào cố ý đăng đi đăng lại chương để tạo hiệu ứng "chương mới" sẽ được xem là spam và bị khóa ngay lập tức.</li>
                </ol>
                <h3 className="mt-2 font-bold px-2">C. Quy Tắc Khi Mua Chương Vip</h3>
                <ol className="px-8 list-decimal">
                    <li>HTruyen sẽ không hoàn lại tiền với bất cứ lý do nào khi bạn đã mua chương.</li>
                    <li>Chương VIP sẽ được đảm bảo luôn mở để đọc tối đa 1 năm kể từ ngày bạn mua chương.</li>
                    <li>Nếu truyện có vấn đề bản quyền, chúng tôi sẽ khóa truyện mà không hoàn lại tiền.</li>
                    <li>Đối với truyện vi phạm nội quy, truyện sẽ bị khóa, chúng tôi sẽ cung cấp file EPUB nếu không ảnh hưởng đến các bên hoặc vi phạm luật pháp trong vòng 10 ngày kể từ ngày khóa.</li>
                    <li>Truyện có thể chỉ có thể đọc trên web hoặc trên app, và cũng có thể là cả 2, bạn cần lưu ý trước khi mua chương.</li>
                </ol>
                <h3 className="mt-2 font-bold px-2">D. Quy Tắc Các Dịch Vụ Tiêu Phí Khác</h3>
                <ol className="px-8 list-decimal">
                    <li>HTruyen sẽ không hoàn lại tiền với bất cứ lý do nào khi bạn đã tiến hành giao dịch TLT với hệ thống.</li>
                    <li>Trước khi tiến hành tiêu phí, HTruyen có trách nhiệm thông báo đầy đủ thông tin về dịch vụ tiêu phí. Người dùng phải tự xem xét thật kỹ nhu cầu và tự chịu trách nhiệm trước khi tiến hành thanh toán.</li>
                    <li className="mb-2">Chúng tôi chỉ hỗ trợ các trường hợp giao dịch bị lỗi hệ thống thông qua các kênh chính thức.</li>
                </ol>
            </article>
        </div>
    )
}

export default Rules;