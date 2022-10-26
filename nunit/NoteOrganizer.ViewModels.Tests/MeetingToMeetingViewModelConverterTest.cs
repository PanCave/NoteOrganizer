using FluentAssertions;
using Moq;
using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels.Converter;
using NoteOrganizer.ViewModels.Interfaces;
using NUnit.Framework;

namespace NoteOrganizer.ViewModels.Tests
{
  [TestFixture]
  public class MeetingToMeetingViewModelConverterTest
  {
    private MockRepository mockRepository = new MockRepository(MockBehavior.Strict);

    private TimeOnly lastEndTime;

    [Test]
    public void No_Collission_Meetings_Should_Result_No_Collisions_Test()
    {
      MeetingToMeetingViewModelConverter subjectUnderTest = new MeetingToMeetingViewModelConverter();

      Mock<IMeeting> meeting1Mock = mockRepository.Create<IMeeting>();
      Mock<IMeeting> meeting2Mock = mockRepository.Create<IMeeting>();
      Mock<IMeeting> meeting3Mock = mockRepository.Create<IMeeting>();
      Mock<IMeeting> meeting4Mock = mockRepository.Create<IMeeting>();

      meeting1Mock.Setup(m => m.StartTime).Returns(new TimeOnly(10, 0, 0));
      meeting1Mock.Setup(m => m.EndTime).Returns(new TimeOnly(10, 30, 0));
      meeting1Mock.Setup(m => m.Title).Returns("title1");
      meeting1Mock.Setup(m => m.Identifier).Returns("id1");
      meeting1Mock.Setup(m => m.Duration).Returns(new TimeSpan(0, 30, 0));
      meeting2Mock.Setup(m => m.StartTime).Returns(new TimeOnly(10, 30, 0));
      meeting2Mock.Setup(m => m.EndTime).Returns(new TimeOnly(11, 0, 0));
      meeting2Mock.Setup(m => m.Title).Returns("title2");
      meeting2Mock.Setup(m => m.Identifier).Returns("id2");
      meeting2Mock.Setup(m => m.Duration).Returns(new TimeSpan(0, 30, 0));
      meeting3Mock.Setup(m => m.StartTime).Returns(new TimeOnly(11, 30, 0));
      meeting3Mock.Setup(m => m.EndTime).Returns(new TimeOnly(12, 0, 0));
      meeting3Mock.Setup(m => m.Title).Returns("title3");
      meeting3Mock.Setup(m => m.Identifier).Returns("id3");
      meeting3Mock.Setup(m => m.Duration).Returns(new TimeSpan(0, 30, 0));
      meeting4Mock.Setup(m => m.StartTime).Returns(new TimeOnly(12, 0, 0));
      meeting4Mock.Setup(m => m.EndTime).Returns(new TimeOnly(14, 30, 0));
      meeting4Mock.Setup(m => m.Title).Returns("title4");
      meeting4Mock.Setup(m => m.Identifier).Returns("id4");
      meeting4Mock.Setup(m => m.Duration).Returns(new TimeSpan(2, 30, 0));

      lastEndTime = new TimeOnly(9, 0, 0);

      IMeetingViewModel meeting1ViewModel = subjectUnderTest.Convert(meeting1Mock.Object, lastEndTime);
      meeting1ViewModel.Height.Should().Be(30 * 3);
      meeting1ViewModel.Margin.Should().Be(60 * 3);
      meeting1ViewModel.Title.Should().Be("title1");
      meeting1ViewModel.Identifier.Should().Be("id1");
      meeting1ViewModel.Time.Should().Be("10:00 - 10:30 Uhr");
      meeting1ViewModel.BackgroundColor.Should().BeDefined();
      meeting1ViewModel.BorderColor.Should().BeDefined();
      meeting1ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      lastEndTime = meeting1Mock.Object.EndTime;

      IMeetingViewModel meeting2ViewModel = subjectUnderTest.Convert(meeting2Mock.Object, lastEndTime);
      meeting2ViewModel.Height.Should().Be(30 * 3);
      meeting2ViewModel.Margin.Should().Be(0);
      meeting2ViewModel.Title.Should().Be("title2");
      meeting2ViewModel.Identifier.Should().Be("id2");
      meeting2ViewModel.Time.Should().Be("10:30 - 11:00 Uhr");
      meeting2ViewModel.BackgroundColor.Should().BeDefined();
      meeting2ViewModel.BorderColor.Should().BeDefined();
      meeting2ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      lastEndTime = meeting2Mock.Object.EndTime;

      IMeetingViewModel meeting3ViewModel = subjectUnderTest.Convert(meeting3Mock.Object, lastEndTime);
      meeting3ViewModel.Height.Should().Be(30 * 3);
      meeting3ViewModel.Margin.Should().Be(30 * 3);
      meeting3ViewModel.Title.Should().Be("title3");
      meeting3ViewModel.Identifier.Should().Be("id3");
      meeting3ViewModel.Time.Should().Be("11:30 - 12:00 Uhr");
      meeting3ViewModel.BackgroundColor.Should().BeDefined();
      meeting3ViewModel.BorderColor.Should().BeDefined();
      meeting3ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      lastEndTime = meeting3Mock.Object.EndTime;

      IMeetingViewModel meeting4ViewModel = subjectUnderTest.Convert(meeting4Mock.Object, lastEndTime);
      meeting4ViewModel.Height.Should().Be(150 * 3);
      meeting4ViewModel.Margin.Should().Be(0);
      meeting4ViewModel.Title.Should().Be("title4");
      meeting4ViewModel.Identifier.Should().Be("id4");
      meeting4ViewModel.Time.Should().Be("12:00 - 14:30 Uhr");
      meeting4ViewModel.BackgroundColor.Should().BeDefined();
      meeting4ViewModel.BorderColor.Should().BeDefined();
      meeting4ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      mockRepository.VerifyAll();
    }

    [Test]
    public void Collission_Meetings_Should_Result_Negative_Margin_Test()
    {
      MeetingToMeetingViewModelConverter subjectUnderTest = new MeetingToMeetingViewModelConverter();

      Mock<IMeeting> meeting1Mock = mockRepository.Create<IMeeting>();
      Mock<IMeeting> meeting2Mock = mockRepository.Create<IMeeting>();

      meeting1Mock.Setup(m => m.StartTime).Returns(new TimeOnly(10, 0, 0));
      meeting1Mock.Setup(m => m.EndTime).Returns(new TimeOnly(12, 00, 0));
      meeting1Mock.Setup(m => m.Title).Returns("title1");
      meeting1Mock.Setup(m => m.Identifier).Returns("id1");
      meeting1Mock.Setup(m => m.Duration).Returns(new TimeSpan(2, 0, 0));
      meeting2Mock.Setup(m => m.StartTime).Returns(new TimeOnly(11, 00, 0));
      meeting2Mock.Setup(m => m.EndTime).Returns(new TimeOnly(13, 0, 0));
      meeting2Mock.Setup(m => m.Title).Returns("title2");
      meeting2Mock.Setup(m => m.Identifier).Returns("id2");
      meeting2Mock.Setup(m => m.Duration).Returns(new TimeSpan(2, 0, 0));

      lastEndTime = new TimeOnly(9, 0, 0);

      IMeetingViewModel meeting1ViewModel = subjectUnderTest.Convert(meeting1Mock.Object, lastEndTime);
      meeting1ViewModel.Height.Should().Be(120 * 3);
      meeting1ViewModel.Margin.Should().Be(60 * 3);
      meeting1ViewModel.Title.Should().Be("title1");
      meeting1ViewModel.Identifier.Should().Be("id1");
      meeting1ViewModel.Time.Should().Be("10:00 - 12:00 Uhr");
      meeting1ViewModel.BackgroundColor.Should().BeDefined();
      meeting1ViewModel.BorderColor.Should().BeDefined();
      meeting1ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      lastEndTime = meeting1Mock.Object.EndTime;

      IMeetingViewModel meeting2ViewModel = subjectUnderTest.Convert(meeting2Mock.Object, lastEndTime);
      meeting2ViewModel.Height.Should().Be(120 * 3);
      meeting2ViewModel.Margin.Should().Be(-60 * 3);
      meeting2ViewModel.Title.Should().Be("title2");
      meeting2ViewModel.Identifier.Should().Be("id2");
      meeting2ViewModel.Time.Should().Be("11:00 - 13:00 Uhr");
      meeting2ViewModel.BackgroundColor.Should().BeDefined();
      meeting2ViewModel.BorderColor.Should().BeDefined();
      meeting2ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      mockRepository.VerifyAll();
    }

    [Test]
    public void Collissions_Should_Result_Correct_Margin_For_Subsequent_Meetings_Test()
    {
      MeetingToMeetingViewModelConverter subjectUnderTest = new MeetingToMeetingViewModelConverter();

      Mock<IMeeting> meeting1Mock = mockRepository.Create<IMeeting>();
      Mock<IMeeting> meeting2Mock = mockRepository.Create<IMeeting>();
      Mock<IMeeting> meeting3Mock = mockRepository.Create<IMeeting>();
      Mock<IMeeting> meeting4Mock = mockRepository.Create<IMeeting>();

      meeting1Mock.Setup(m => m.StartTime).Returns(new TimeOnly(9, 30, 0));
      meeting1Mock.Setup(m => m.EndTime).Returns(new TimeOnly(10, 00, 0));
      meeting1Mock.Setup(m => m.Title).Returns("title1");
      meeting1Mock.Setup(m => m.Identifier).Returns("id1");
      meeting1Mock.Setup(m => m.Duration).Returns(new TimeSpan(0, 30, 0));
      meeting2Mock.Setup(m => m.StartTime).Returns(new TimeOnly(9, 45, 0));
      meeting2Mock.Setup(m => m.EndTime).Returns(new TimeOnly(10, 45, 0));
      meeting2Mock.Setup(m => m.Title).Returns("title2");
      meeting2Mock.Setup(m => m.Identifier).Returns("id2");
      meeting2Mock.Setup(m => m.Duration).Returns(new TimeSpan(1, 0, 0));
      meeting3Mock.Setup(m => m.StartTime).Returns(new TimeOnly(10, 15, 0));
      meeting3Mock.Setup(m => m.EndTime).Returns(new TimeOnly(10, 30, 0));
      meeting3Mock.Setup(m => m.Title).Returns("title3");
      meeting3Mock.Setup(m => m.Identifier).Returns("id3");
      meeting3Mock.Setup(m => m.Duration).Returns(new TimeSpan(0, 15, 0));
      meeting4Mock.Setup(m => m.StartTime).Returns(new TimeOnly(10, 30, 0));
      meeting4Mock.Setup(m => m.EndTime).Returns(new TimeOnly(10, 45, 0));
      meeting4Mock.Setup(m => m.Title).Returns("title4");
      meeting4Mock.Setup(m => m.Identifier).Returns("id4");
      meeting4Mock.Setup(m => m.Duration).Returns(new TimeSpan(0, 15, 0));

      lastEndTime = new TimeOnly(9, 0, 0);

      IMeetingViewModel meeting1ViewModel = subjectUnderTest.Convert(meeting1Mock.Object, lastEndTime);
      meeting1ViewModel.Height.Should().Be(30 * 3);
      meeting1ViewModel.Margin.Should().Be(30 * 3);
      meeting1ViewModel.Title.Should().Be("title1");
      meeting1ViewModel.Identifier.Should().Be("id1");
      meeting1ViewModel.Time.Should().Be("9:30 - 10:00 Uhr");
      meeting1ViewModel.BackgroundColor.Should().BeDefined();
      meeting1ViewModel.BorderColor.Should().BeDefined();
      meeting1ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      lastEndTime = meeting1Mock.Object.EndTime;

      IMeetingViewModel meeting2ViewModel = subjectUnderTest.Convert(meeting2Mock.Object, lastEndTime);
      meeting2ViewModel.Height.Should().Be(60 * 3);
      meeting2ViewModel.Margin.Should().Be(-15 * 3);
      meeting2ViewModel.Title.Should().Be("title2");
      meeting2ViewModel.Identifier.Should().Be("id2");
      meeting2ViewModel.Time.Should().Be("9:45 - 10:45 Uhr");
      meeting2ViewModel.BackgroundColor.Should().BeDefined();
      meeting2ViewModel.BorderColor.Should().BeDefined();
      meeting2ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      lastEndTime = meeting2Mock.Object.EndTime;

      IMeetingViewModel meeting3ViewModel = subjectUnderTest.Convert(meeting3Mock.Object, lastEndTime);
      meeting3ViewModel.Height.Should().Be(15 * 3);
      meeting3ViewModel.Margin.Should().Be(-30 * 3);
      meeting3ViewModel.Title.Should().Be("title3");
      meeting3ViewModel.Identifier.Should().Be("id3");
      meeting3ViewModel.Time.Should().Be("10:15 - 10:30 Uhr");
      meeting3ViewModel.BackgroundColor.Should().BeDefined();
      meeting3ViewModel.BorderColor.Should().BeDefined();
      meeting3ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      lastEndTime = meeting3Mock.Object.EndTime;

      IMeetingViewModel meeting4ViewModel = subjectUnderTest.Convert(meeting4Mock.Object, lastEndTime);
      meeting4ViewModel.Height.Should().Be(15 * 3);
      meeting4ViewModel.Margin.Should().Be(0);
      meeting4ViewModel.Title.Should().Be("title4");
      meeting4ViewModel.Identifier.Should().Be("id4");
      meeting4ViewModel.Time.Should().Be("10:30 - 10:45 Uhr");
      meeting4ViewModel.BackgroundColor.Should().BeDefined();
      meeting4ViewModel.BorderColor.Should().BeDefined();
      meeting4ViewModel.MouseOverBackgroundColor.Should().BeDefined();

      mockRepository.VerifyAll();
    }
  }
}