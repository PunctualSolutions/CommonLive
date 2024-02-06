namespace ZhengDianWaiBao.CommonLive
{
    public struct AnchorInfo
    {
        public AnchorInfo(OpenBLive.Runtime.Data.AnchorInfo info)
        {
            Id = info.uid;
            Name = info.userName;
            Face = info.userFace;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Face { get; private set; }
    }
}