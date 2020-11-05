using DataLayer.Models;
using DataLayer.Repositories;

namespace DataLayer.Services
{
    public class MainService
    {
        private readonly NFixEntities _db = new NFixEntities();
        private MainRepo<TblClient> _client;
        private MainRepo<TblProduct> _product;
        private MainRepo<TblAd> _ad;
        private MainRepo<TblBlogCommentRel> _blogCommentRel;
        private MainRepo<TblBlogKeywordRel> _blogKeywordRel;
        private MainRepo<TblCatagory> _catagory;
        private MainRepo<TblImage> _image;
        private MainRepo<TblKeyword> _keyword;
        private MainRepo<TblBlog> _blog;
        private MainRepo<TblProductCommentRel> _productCommentRel;
        private MainRepo<TblProductImageRel> _productImageRel;
        private MainRepo<TblProductKeywordRel> _productKeywordRel;
        private MainRepo<TblProductPropertyRel> _productPropertyRel;
        private MainRepo<TblVideoCommentRel> _videoCommentRel;
        private MainRepo<TblProperty> _property;
        private MainRepo<TblVideoCatagory> _videoCatagory;
        private MainRepo<TblVideoKeyword> _videoKeyword;
        private MainRepo<TblTutor> _tutor;
        private MainRepo<TblOrder> _order;
        private MainRepo<TblDeal> _deal;
        private MainRepo<TblDealPropertyRel> _dealPropertyRel;
        private MainRepo<TblUserPass> _userPass;
        private MainRepo<TblClientProductRel> _clientProductRel;
        private MainRepo<TblDiscount> _discount;
        private MainRepo<TblLog> _log;
        private MainRepo<TblRole> _role;
        private MainRepo<TblTuotorVideoRel> _tuotorVideoRel;
        private MainRepo<TblVideo> _video;
        private MainRepo<TblComment> _comment;

        public MainRepo<TblClient> Client => _client ?? (_client = new MainRepo<TblClient>(_db));
        public MainRepo<TblProduct> Product => _product ?? (_product = new MainRepo<TblProduct>(_db));
        public MainRepo<TblAd> Ad => _ad ?? (_ad = new MainRepo<TblAd>(_db));
        public MainRepo<TblBlogCommentRel> BlogCommentRel => _blogCommentRel ?? (_blogCommentRel = new MainRepo<TblBlogCommentRel>(_db));
        public MainRepo<TblBlogKeywordRel> BlogKeywordRel => _blogKeywordRel ?? (_blogKeywordRel = new MainRepo<TblBlogKeywordRel>(_db));
        public MainRepo<TblCatagory> Catagory => _catagory ?? (_catagory = new MainRepo<TblCatagory>(_db));
        public MainRepo<TblImage> Image => _image ?? (_image = new MainRepo<TblImage>(_db));
        public MainRepo<TblKeyword> Keyword => _keyword ?? (_keyword = new MainRepo<TblKeyword>(_db));
        public MainRepo<TblBlog> Blog => _blog ?? (_blog = new MainRepo<TblBlog>(_db));
        public MainRepo<TblProductCommentRel> ProductCommentRel => _productCommentRel ?? (_productCommentRel = new MainRepo<TblProductCommentRel>(_db));
        public MainRepo<TblProductImageRel> ProductImageRel => _productImageRel ?? (_productImageRel = new MainRepo<TblProductImageRel>(_db));
        public MainRepo<TblProductKeywordRel> ProductKeywordRel => _productKeywordRel ?? (_productKeywordRel = new MainRepo<TblProductKeywordRel>(_db));
        public MainRepo<TblProductPropertyRel> ProductPropertyRel => _productPropertyRel ?? (_productPropertyRel = new MainRepo<TblProductPropertyRel>(_db));
        public MainRepo<TblVideoCommentRel> VideoCommentRel => _videoCommentRel ?? (_videoCommentRel = new MainRepo<TblVideoCommentRel>(_db));
        public MainRepo<TblProperty> Property => _property ?? (_property = new MainRepo<TblProperty>(_db));
        public MainRepo<TblVideoCatagory> VideoCatagory => _videoCatagory ?? (_videoCatagory = new MainRepo<TblVideoCatagory>(_db));
        public MainRepo<TblVideoKeyword> VideoKeyword => _videoKeyword ?? (_videoKeyword = new MainRepo<TblVideoKeyword>(_db));
        public MainRepo<TblTutor> Tutor => _tutor ?? (_tutor = new MainRepo<TblTutor>(_db));
        public MainRepo<TblOrder> Order => _order ?? (_order = new MainRepo<TblOrder>(_db));
        public MainRepo<TblDeal> Deal => _deal ?? (_deal = new MainRepo<TblDeal>(_db));
        public MainRepo<TblDealPropertyRel> DealPropertyRel => _dealPropertyRel ?? (_dealPropertyRel = new MainRepo<TblDealPropertyRel>(_db));
        public MainRepo<TblUserPass> UserPass => _userPass ?? (_userPass = new MainRepo<TblUserPass>(_db));
        public MainRepo<TblClientProductRel> ClientProductRel => _clientProductRel ?? (_clientProductRel = new MainRepo<TblClientProductRel>(_db));
        public MainRepo<TblDiscount> Discount => _discount ?? (_discount = new MainRepo<TblDiscount>(_db));
        public MainRepo<TblLog> Log => _log ?? (_log = new MainRepo<TblLog>(_db));
        public MainRepo<TblRole> Role => _role ?? (_role = new MainRepo<TblRole>(_db));
        public MainRepo<TblTuotorVideoRel> TuotorVideoRel => _tuotorVideoRel ?? (_tuotorVideoRel = new MainRepo<TblTuotorVideoRel>(_db));
        public MainRepo<TblVideo> Video => _video ?? (_video = new MainRepo<TblVideo>(_db));
        public MainRepo<TblComment> Comment => _comment ?? (_comment = new MainRepo<TblComment>(_db));

    }
}
