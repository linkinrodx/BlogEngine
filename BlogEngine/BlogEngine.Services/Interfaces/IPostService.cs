using BlogEngine.Services.Models;
using System.Collections.Generic;

namespace BlogEngine.Services.Interfaces
{
    public interface IPostService
    {
        List<PostResult> GetPost(GetPostParameters parameters);

        List<PostResult> GetPostByAuthorId(GetPostByAuthorIdParameters parameters);

        List<PostResult> GetPostSubmmited(GetPostSubmmitedParameters parameters);

        PostResult AddPost(AddPostParameters parameters);

        PostResult EditPost(EditPostParameters parameters);

        PostResult SubmitPost(SubmitPostParameters parameters);

        PostResult ApprovePost(ApprovePostParameters parameters);

        PostResult RejectPost(RejectPostParameters parameters);
    }
}
