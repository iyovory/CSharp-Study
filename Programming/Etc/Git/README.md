https://desktop.github.com/

레파지토리 생성시 Git ignore에서 VisualStudio 선택

좌측상단에 레파지토리-우측클릭 하면 폴더 열 수 있음

좌측상단 3번째에 Fetch origin 클릭하면 pull push patch 가능

clone 클릭시 가져오기 가능

### 커밋
Changes - .ignore
파일에 우클릭하면 변경하고 필요없는 파일 우측 클릭하면 ignore folder뜸. 폴더 선택(git/.vs 폴더)
메모장으로 열어보면 이 폴더 안에있는건 안올라감

Changes - Discard Change
파일에 우클릭하면 변경 취소됨(이전 저장된데까지 돌아감)

History - Checkout Commit
잠깐 예전 히스토리 상황으로 돌아감(테스트할때 씀)
다시 돌아가려면 상단 두번째에 Current branch 클릭 후 브런치를 main으로 하면 됨!
저장해도 무시됨

* 파일삭제시
	깃 기록삭제하지말고 옛날껄로 되돌리는게 아니라 옛날껄로 업데이트 해서 커밋하기 커밋명은 작업 취소 이런식으로 

### 충돌났을때 conflict
```
<<<<<HEAD 
		로컬(나)
=====
		원격(상대방)
>>>>> 
```

같은파일인데 다른부분을 작업했으면 충돌 발생 안함.

### 깃메시지 규칙
타입(스코프): 제목

본문

바닥글

첫 문자는 대문자로 작성
명령문으로 사용하며 과거형을 사용하지 않음(구현했다X 구현)
본문에서는 어떻게했는지 작성하지말고 무엇을 왜 개발하였는지

타입(스코프) - fix feat(기능추가) test refactor docs (문서, 주석 수정) build(빌드 관련 수정)

### 분기 branch
Feat/Monster
Feat/Player

a브랜치에 b브랜치 내용을 붙이고 싶으면 
상단 두번째 브랜치 클릭하고
a브랜치 선택하고 밑에 Choose a branch to ~ 클릭하고 b브랜치 클릭 후 Create merge commit
(rebase 추천. 하고 delete뜨면 delete누르기 안그러면 터짐)

### Pull requests
base: main <- compare: Feat/Player
플레이어 기능 게임에 추가 부탁드립니다
feat: 1. 플레이어 체력 추가
fix: 2. 플레이어 ~ 변경
Create pull request 다른사람한테 누르면 요청을 하는거 
댓글 달 수 있음(컨벤션)
Rebase and merge 누르면 수락
끊어버릴 수도 있음(Close with comment)


[마크다운 에디터 추천]
1. Visual Studio Code + Extension [Markdown All in One]
2. Obsidian










