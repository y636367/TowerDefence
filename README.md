<div align=center> 
  
<h1>:alien: Space_Invasion_(Demo)</h1><br>
몰려오는 몬스터들을 막아내자. <br>
생각보다 쉽지 않을걸...? <br>

<br>

<img src="https://github.com/user-attachments/assets/49b0f632-1716-4a72-945f-cf39af4309d6">

</div>

## :calendar: 목차
  1. [개요](#page_with_curl-개요)
  2. [플레이 영상](#movie_camera-플레이-영상)
  3. [실행 방법](#memo-실행방법)
  4. [게임 설명](#video_game-게임설명)
  5. [게임 정보](#mag_right-게임정보)
  6. [트러블 슈팅](#loop-트러블슈팅)

## :page_with_curl: 개요
 - 프로젝트 이름: Space_Invasion_(Demo)
 - 개발 기간: 2023.04.07-2023.05.04
 - 개발 목적 및 동기:<br><br>
 Singleton 패턴, UI 상호작용, 해상도 옵션과 같은 간단한 내용을 짧은 시간에 직접적으로 적용해보기에 가장 적합하다고 판단<br>
 킬링 타임용으로 만들어 틈틈이 플레이 할 목적으로 개발을 결심
 
 - 개발 엔진 및 사용언어: <img src="https://img.shields.io/badge/unity-000000?style=for-the-badge&logo=unity&logoColor=white"> / <img src="https://img.shields.io/badge/-C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white">
 - :file_folder: [프로젝트 설명 PPT 다운로드](https://drive.google.com/uc?export=download&id=10hu3eTE6sJRxGbgwrYv_shCjUMncWiR9)

## :movie_camera: 플레이 영상
[▶ 영상 보기](https://github.com/user-attachments/assets/4dc05ea4-173c-42fe-800d-45c129f5ced9)

## :memo: 실행방법
 1. :file_folder: [게임 다운로드 링크](https://drive.google.com/file/d/1Ci_ASu_GXxZqVirqHPJliRJ7JbKbP7_j/view?usp=sharing)
 2. 위 링크를 클릭하여 'TowerDefence' 파일을 다운로드
 3. 압축을 해제 후 'TowerDefence.exe' 실행 
   
 ## :video_game: 게임설명
<details>
<summary>게임 설명 보기</summary>
 
  - ### 시작, 설정

<div align=center> 
  
|<img src="https://github.com/y636367/TowerDefence/assets/63005842/9d70e618-9796-4a63-96ad-116339feb6da" width="400" height="240"/>|<img src="https://github.com/y636367/TowerDefence/assets/63005842/eb05c001-a8a5-4c70-883a-2b3f27a99c7d" width="400" height="240"/>|
|---|---|
|<div align=center>시작 화면</div>|<div align=center>설정 화면</div>|

</div>
<br>

  - ### 스테이지 선택

<div align=center> 
  
|<img src="https://github.com/y636367/TowerDefence/assets/63005842/9783d868-94bd-4f9f-86cf-feb641a7da01" width="400" height="240"/>|<img src="https://github.com/y636367/TowerDefence/assets/63005842/44b22fa4-7069-4a4f-8dd2-c4c51885c760" width="400" height="240"/>|
|---|---|
|<div align=center>스테이지 선택</div>|<div align=center>스테이지 잠금</div>|

이전 스테이지를 클리어 하면 다음 스테이지가 해금되는 방식입니다.<br>
(현재 1스테이지만 구현된 상태입니다.) <br>

</div>
</details>

## :mag_right: 게임정보
<details>
<summary>게임 정보 보기</summary>

 - ### 인게임 화면

<div align=center> 
  
|<img src="https://github.com/y636367/TowerDefence/assets/63005842/14b0fde2-cb31-48f2-941b-7f6b3309f905" width="400" height="240"/>|<img src="https://github.com/y636367/TowerDefence/assets/63005842/578f0ba6-e55e-4c2a-be6e-9015d2fc23ee" width="400" height="240"/>|
|---|---|
|<div align=center>튜토리얼</div>|<div align=center>게임 진행</div>|
|<img src="https://github.com/y636367/TowerDefence/assets/63005842/92ea8220-8522-4397-9321-e6741e7060d2" width="400" height="240"/>|<img src="https://github.com/y636367/TowerDefence/assets/63005842/1f0ce93b-5ee5-4171-a650-16e4a3253a94" width="400" height="240"/>|
|<div align=center>타워 설치</div>|<div align=center>타워 강화</div>|

게임 시작 전 튜토리얼을 통해 기본 조작을 익힐 수 있습니다. <br>
하단 바에서는 일시정지, 목숨/코인 확인, 타워 설치가 가능합니다. <br>
오른쪽 하단 버튼을 통해 웨이브를 빠르게 넘길 수 있으며, 설치된 타워는 선택하여 강화/처분이 가능합니다. <br>

</div>

</details>

## :loop: 트러블슈팅
<details>
<summary>트러블슈팅 보기 (경로 이탈, 우선순위 타겟팅 문제)</summary>
  
  - ### 몬스터의 이동 경로 이탈 문제 -> 발사체의 몬스터 피격 판정
<br>
<div align=center> 
  
|<img src="https://github.com/user-attachments/assets/a6fbc696-186e-4bfc-82a2-2af7ca79872e" width="400" height="240"/>|<img src="https://github.com/user-attachments/assets/46be66e6-6ebf-47b2-9b99-10c742b82812" width="400" height="240"/>|
|---|---|

</div>
<br>

 - 문제 : 발사체 피격 시 몬스터가 이동 경로에서 조금씩 이탈하는 문제가 발생
 - 원인 : Collider 의 물리적 충돌로 인해 조금씩 밀려나게 됨
 - 해결 : 몬스터와 발사체 간 사이 거리 값을 계산, 남은거리<=이동해야할 거리 조건을 통해 피격 판정 변경

<br>

  - ### 타워의 몬스터 공격 우선 순위 선정 문제
<br>
<div align=center> 
  
|<img src="https://github.com/user-attachments/assets/4f59d7d2-735f-45a0-9cd0-097bd3dccd06" width="400" height="240"/>|<img src="https://github.com/user-attachments/assets/d36b4c73-b0a5-4196-a29e-c19537a360bd" width="400" height="240"/>|
|---|---|

</div>
<br>

 - 문제 : 타워와 몬스터 사이 거리가 가장 짧은 몬스터만 피격 하는 문제 발생
 - 원인 : 타워의 공격 범위 안에 들어간 몬스터들 전부를 타겟으로 설정하여 그 중 거리가 짧은 몬스터만을 공격
 - 해결 : 최초 공격 대상으로 선정된 타겟이 범위 바깥으로 나가거나 몬스터 사망 시에만 새로 거리가 짧은 몬스터를 타겟으로 선정

</details>
