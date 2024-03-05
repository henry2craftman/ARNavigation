# Station-J : 제물포 스마트 Station-J 플랫폼 개발 및 콘텐츠 구축사업
Station J는 제물포 스마트 Station-J 플랫폼 개발 및 콘텐츠 구축사업의 일환으로, 사용자가 제물포 지역을 걸어다니며 이용할 수 있는 ARNavigation, 특정 위치에서 활용할 수 있는 AR포토존 및 AR도슨트를 포함합니다.
<br>
<br>
![ezgif-1-eb3981f90d](https://github.com/henry2craftman/ARNavigation/assets/141684228/27f395b6-70f9-41b1-ad73-484e9786abc7)


---
<br>

## 상태 및 전제조건
> Unity Version: 2022.3.2f1

> Platform: Android

> 지원기기: [ARCore 지원 기기](https://developers.google.com/ar/devices?hl=ko, "ARCore 지원 기기")

---
<br>

## 시작하는 방법
### 1. ARCore Extension Package 설치
AR Foundation용 [ARCore Extension Package](https://developers.google.com/ar/develop/unity-arf/getting-started-extensions?hl=ko)는 Unity의 AR Foundation 패키지에 기능을 추가하여 앱에서 Cloud Anchors, 카메라 구성 필터, 녹화 및 재생과 같은 기능을 사용할 수 있습니다.

<br>

### 2. Google Cloud Platform API 사용 설정
[Google Cloud Platform](https://cloud.google.com/, "Google Cloud Platform")는 구글 클라우드 플랫폼은 구글 검색과 유튜브와 같은 최종 사용자 제품을 위해 내부적으로 구글이 사용하는, 동일한 지원 인프라스트럭처 위에서 호스팅을 제공하는 구글의 클라우드 컴퓨팅 서비스 입니다.
1. 프로젝트 등록
이미지와 설명
2. API 사용 설정
이미지와 설명
3. API Key 발급
이미지와 설명

<br>

### 3. Geospatial API 사용설정
Google의 [ARCore Geospatial API](https://developers.google.com/ar/develop/geospatial?hl=ko, "Google ARCore 
 Geospatial")는 Google 스트리트 뷰가 적용되는 지역의 VPS(Visual Positioning System) 기반의 현지화를 돕는 API입니다.

#### 3-1. Geospatial API사용 설정
> Project Settings -> XR Plug-in Management -> ARCore Extensions -> Enable Geospatial
이미지와 설명

#### 3-2. 사용 설정 및 API Key 사용 설명
Geospatial API를 사용하기 위해선 Google Cloud Platform에 프로젝트를 등록하고 API 사용설정을 하고, API Key를 발급받아야 합니다.

> Android Authentication Stratage -> API Key로 설정, Android API Key 입력
이미지와 설명

#### 3-3. Geospatial Creator API 사용 설정
ARCore 및 Google Maps Platform에서 제공하는 [Geospatial Creator](https://developers.google.com/ar/geospatialcreator/intro?hl=ko, "Geospatial Creator")를 사용하면 개발자와 크리에이터 모두가 Photorealistic 3D 카드를 통해 실제 위치에서 강력하고 매력적인 3D 디지털 콘텐츠를 시각화, 빌드, 실행할 수 있습니다.

>  Project Settings -> XR Plug-in Management -> ARCore Extensions -> Enable Geospatial Creator
이미지와 설명

#### 3-4. Cesium Pacakge 설치
3D 지리공간 플랫폼 [Cesium](https://cesium.com/, "Cesium")은 강력한 3D 지리 공간 응용 프로그램을 만들기 위한 기본 개방형 플랫폼입니다.

> Project Settings -> Package Manager -> Scoped Registries -> +버튼 클릭 후 내용 입력
이미지와 설명

<br>

### 4. Naver Cloud Platform API 사용 설정
[Naver Cloud Platform](https://www.ncloud.com/, "Never Cloud Platform")은 네이버, 라인, 밴드, 스노우, 웹툰 등 성공적인 네이버 글로벌 서비스를 위한 IT 서비스 플랫폼입니다.

> Naver Cloud Platform 접속 -> 가입 -> API Key 발급
이미지와 설명

#### 4-1. Directions5 API 사용 설정정
[Direction 5 API](https://api.ncloud-docs.com/docs/ai-naver-mapsdirections, "Direction 5 API")는 사용자가 지정한 출발지/목적지 정보에 따라 경로 관련 정보를 제공합니다.

> Naver Cloud Platform 접속 -> 가입 -> API Key 발급
이미지와 설명

<details>
<summary>내용</summary>
이미지
</details>

#### 4-2. Static Map API 사용 설정
[Static Map API](https://api.ncloud-docs.com/docs/ai-naver-mapsstaticmap, "Static Map API")는 요청된 URL 매개변수를 기반으로 웹 페이지에 표시할 수 있는 이미지로 지도를 반환

<details>
<summary>내용</summary>
이미지
</details>

#### 4-3. API Key 사용 설정정
<details>
<summary>내용</summary>
이미지
</details>

<br>

### 5. Android Build Settings
<details>
<summary>내용</summary>
이미지
</details>

---
<br>

## 해당 프로젝트를 사용하여 개발
### ROI 변경 방법
<details>
<summary>내용</summary>
이미지
</details>

<br>

### Directions5 Json 구조
<details>
<summary>내용</summary>
이미지
</details>

<br>

### Static map API 링크

---
<br>
  
## License
- License.md
