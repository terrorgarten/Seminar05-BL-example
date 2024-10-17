# Seminar 5 - Business Layer, Facades, DTOs, Services

In this seminar, we will go through the Business Layer, where you will be able to see & create services, facades and DTO. You say that this is an introduction to business layer.

## Task 0

It is required to have a basic understanding of what Service, DTO and Facade is. If you are missing this knowledge, please see the [WIKI](https://gitlab.fi.muni.cz/pv179/wiki) for information about these topics.


## Task 1 - Clone this repository:

```
git clone https://gitlab.fi.muni.cz/pv179/seminar-05
```

## TASK 2 - Examine the solution

Go through the already written code. It is recommended to check side by side `UserController` and `UserSolutionController`. What you can see there is 2 aproaches to retrieving data. First is using a service that does the "magic" on the background. However the other one might seem more straight forward, however you can already see how confusing and heavily dependent it is on the database model. If we split the `User` into 2 tables,  we would need to change multiple endpoints. Additionally, you can see that there is a new csproj called `Business Layer`. In there, you can see DTOs, DTO mappers and Services. 

1. Create a `UserDTO` (this will be our detailed user DTO)
    - Example:
        ```cs
        public class UserDTO
        {
            public int UserId { get; set; }

            public string Username { get; set; }

            public IEnumerable<PostDTO>? Posts { get; set; }

            ....
        }
        ```

2. Map it From and To `User`.
    - Example mapping from User to `UserDTO`
        ```cs
        public static UserDTO MapToUserDetailDTO(this User user)
        {
            return new UserDTO
            {
                UserId = user.Id,
                Username = user.Username,
                Comments = user.Comments?.Select(a => a.MapToCommentDTO()),
                Posts = user.Posts?.Select(a => a.MapToPostDTO()),
                Followers = user.Followers?.Select(a => a.MapToFollowDTO()),
                Follows = user.Follows?.Select(a => a.MapToFollowDTO()),
            };
        }
        ```
        *Note: We are aware that UserDTO has a few properties missing ... it is up to you to write them.*

3. Make sure that the `UserDTO -> User` and `User -> UserDTO` are in correct files.

4. Add the following method to `IUserService` and implement it:
    ```cs
    public Task<UserDTO?> FindUserByIdAsync(int userId,
            bool includePosts = true,
            bool includeComments = true,
            bool includeFollowTable = true);
    ```

5. Create an endpoint with the following route `[controller]/fetch/user/detail` in `UserSolutionController` and fetch the user based on the `userId` provided in the request.
    <details>
    <summary>Hint: (click to show more)</summary>
    
    ### Example Code
    ```cs
    [HttpGet]
    [Route("[controller]/fetch/user/detail")]
    public async Task<IActionResult> FetchUserDetail(int userId)
    {
        var user = await _userService.FindUserByIdAsync(userId);

        if (user == null)
        {
            return BadRequest();
        }

        return Ok(user);
    }
    ```
    </details>


## TASK 3 - Create/Refactor the Follow Controller

It is completelly up to you, if you refactor the `FollowController` to `FollowService`, or you rewrite it. The recommended way is to refactor it, however sometimes, it is better to just throw the old "garbage" away. In this example, we will write the Service from scratch, however feel free to use "legacy code" for an inspiration on how the core functionality was done so far.

## TASK 4 - Follow Service:

1. Create the following interface with the following methods:
    ```cs
    public interface IFollowService : IBaseService
    {
        public Task<List<int>> GetFollowerIdsAsync(int followeeId);

        public Task<bool> DoesFollowUser(int followerId, int followeeId);

        public Task<bool> FollowUserAsync(int followerId, int followeeId, bool checkIfExists = true, bool save = true);

        public Task<bool> UnFollowUserAsync(int followerId, int followeeId, bool checkIfExists = true, bool save = true);
    }
    ```

2. Create the `FollowService` and `add DBContext` through DI Constructor injection. Additionally, make this service to extend `BaseService`. 

3. Implement the `FollowService`. Here is an example for how Follow method can be implemented:
    ```cs
    public async Task<bool> FollowUserAsync(int followerId, int followeeId, bool checkIfExists = true, bool save = true)
    {
        if (followeeId == followerId)
        {
            return false;
        }

        if (checkIfExists && await DoesFollowUser(followerId, followeeId))
        {
            return false;
        }

        FollowUser(followerId, followeeId);
        await SaveAsync(save);

        return true;
    }

    private void FollowUser(int followerId, int followeeId)
    {
        var follow = new Follow
        {
            FollowerId = followerId,
            FolloweeId = followeeId
        };

        _dBContext.Follows.Add(follow);
    }
    ```

## TASK 5 - The Controller

After creating the service, it is time to create the controller. Since we would like to show you a "side-by-side" different of the controller (before and after), it is recommended to create a new controller called `FollowSolutionController`.

1. Create the Controller and use DI to inject `IUserService` and `IFollowService` using Constructor Injection.

2. Create 2 methods:
    - Follow
        - takes followerId and followeeId
    - Unfollow 
        - takes followerId and followeeId

3. Implement these methods using the 2 injected services.
    <details>
        <summary>Hint: (click to show more)</summary>

        1. Check if user exists
        2. Check if follow/unfollow was successful
        3. Return Success Response
    </details>


## TASK 6 - New Pattern - Facade

Okay, we have successfully created services that make our controllers look clean again. Now, the next task will be to follow multiple users in 1 endpoint. However, you need to think about large requests that will be requesting thousands, or maybe ten thousands of follows per call. Let's see why Facade will help us out :).

1. Create a `BusinessLayer/Facades/FollowFacade` and `IFollowFacade`
2. Inject using a constructor `IFollowService` and `IUserService`
3. Create `FollowInfoDTO` that will contain the following:
    - FollowerId
    - UserSummaryDTO (nullable)
    - WasSuccessful (bool)
4. Add the following method to the `IFollowFacade`
    - `public Task<List<FollowInfoDTO>> FollowUsersAsync(int followerId, params int[] userIds);`
5. Let's implement the method:
    1. We need to split the users to 2 groups. "Followers" and "Non-Followers". We can achieve this by using `IFollowService` and `IUserService`
        ```cs
        var followerIds = await _followService.GetFollowerIdsAsync(followeeId);
        var nonFollowedUserIds = userIds.Except(followerIds).ToArray();
        var users = await _userService.GetUsersAsync(nonFollowedUserIds);
        ```
    2. Now we will create a helper method that will be used to split the users into "successful" and "unsuccessful" follows.
        ```cs
        private async Task<List<FollowInfoDTO>> FollowNonFollowedUsersAsync(int followeeId, List<UserSummaryDTO> users, List<int> failedUserFollowIds)
        {
            var followedUsers = new List<FollowInfoDTO>();

            foreach (var user in users)
            {
                var followerId = user.UserId;

                if (!await _followService.FollowUserAsync(followerId, followeeId, checkIfExists: false, save: false))
                {
                    failedUserFollowIds.Add(followerId);
                }
                else
                {
                    followedUsers.Add(ToFollowInfoDTO(followerId, user, true));
                }
            }

            await _followService.SaveAsync(true);

            return followedUsers;
        }

        private static FollowInfoDTO ToFollowInfoDTO(int id, UserSummaryDTO? user, bool wasSuccessful)
        {
            return new FollowInfoDTO
            {
                FollowerId = id,
                User = user,
                WasSuccessful = wasSuccessful,
            };
        }
        ```
    3. Next, let's get the information about the unsuccessful users:
        ```cs
        private async Task<List<FollowInfoDTO>> GetFailedFollowersAsync(List<int> failedUserFollowIds)
        {
            var failedFollowers = await _userService.GetUsersAsync(failedUserFollowIds.ToArray());

            return failedFollowers.Select(a => ToFollowInfoDTO(a.UserId, a, false)).ToList();
        }
        ```
    4. Now, if you look closer to the first lines of `FollowFacade::FollowUsersAsync` method, you can see that we have retrieved all of the Users, however we are not considering an IDs that no longer exists / never existed. For that, we need to extract these "non-existing" and "existing" ids from request ids.
        ```cs
        private static List<int> ExtractSuccessfulFollows(int[] userIds, List<UserSummaryDTO> users, List<int> failedUserFollowIds)
        {
            return userIds
                .Where(a => users.Select(a => a.UserId).Contains(a))
                .Except(failedUserFollowIds)
                .ToList();
        }

        private List<FollowInfoDTO> GetNonExistingOrFollowedUsers(IEnumerable<int> followedIds, List<int> failedUserFollowIds, int[] userIds)
        {
            var nonExistingOrFollowedUsers = userIds
                .Except(followedIds)
                .Except(failedUserFollowIds)
                .Select(a => ToFollowInfoDTO(a, null, false))
                .ToList();

            return nonExistingOrFollowedUsers;
        }
        ```
    5. Now, all we need to do is return all follower types together:
        ```cs
        return followedUsers
            .Concat(nonExistingOrFollowedUsers)
            .Concat(failedFollowers)
            .ToList();
        ```

## TASK 7 - Controller
- Create POST endpoint (`[Route("[controller]/user/solution/follow/{userId}")]`) and use the following argument `[FromBody] int[] usersToFollow` (this will pull the list from the "request body")
- Call the facade and return the following JSON (anonymous object):
    ```cs
    {
        Message = $"{successfulCount} users successfully followed, {failedCount} failed",
        SuccessfulUsers = successful (list/array),
        UnsuccessfulUsers = failed (list/array),
    }
    ```

## [Bonus] TASK 8 - Think about it ;)

There is one call in `FollowFacade` that can be omitted. Can you find it?